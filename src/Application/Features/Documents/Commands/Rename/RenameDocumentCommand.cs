using Application.Features.Documents.Caching;

namespace Application.Features.Documents.Commands.Rename;


/// <summary>
/// 重命名文档
/// </summary>
[Map(typeof(Document))]
[Description("重命名文档")]
public class RenameDocumentCommand : ICacheInvalidatorRequest<Result<bool>>
{
    /// <summary>
    /// 唯一标识
    /// </summary>
    [Description("唯一标识")]
    public long DocumentId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Description("名称")]
    public string Name { get; set; }

    /// <summary>
    /// 乐观并发标记
    /// </summary>
    [Description("乐观并发标记")]
    public string ConcurrencyStamp { get; set; }

    /// <summary>
    /// 缓存Key值
    /// </summary>
    [JsonIgnore]
    public string CacheKey => DocumentCacheKey.GetAllCacheKey;

    [JsonIgnore]
    public CancellationTokenSource? SharedExpiryTokenSource => DocumentCacheKey.SharedExpiryTokenSource();
}

/// <summary>
/// 处理程序
/// </summary>
public class UpdateDocumentCommandHandler : IRequestHandler<RenameDocumentCommand, Result<long>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateDocumentCommandHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// 业务逻辑
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="cancellationToken">取消标记</param>
    /// <returns>返回处理结果</returns>
    public async Task<Result<bool>> Handle(RenameDocumentCommand request, CancellationToken cancellationToken)
    {
        var documentRename = await _context.Documents
           .SingleOrDefaultAsync(x => x.Id == request.DocumentId && x.ConcurrencyStamp == request.ConcurrencyStamp, cancellationToken)
           ?? throw new NotFoundException($"数据【{request.DocumentId}】未找到");

        documentRename = _mapper.Map(request, documentRename);
        //Document.AddDomainEvent(new UpdatedEvent<Document>(Document));
        _context.Documents.Update(documentRename);
        var success = await _context.SaveChangesAsync(cancellationToken) > 0;
        return await Result<bool>.SuccessOrFailureAsync(success, success, new string[] { "操作失败" });
    }
}
