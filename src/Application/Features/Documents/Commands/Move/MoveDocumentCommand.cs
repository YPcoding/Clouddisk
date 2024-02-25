using Application.Features.Documents.Caching;

namespace Application.Features.Documents.Commands.Move;


/// <summary>
/// 移动文档
/// </summary>
[Map(typeof(Document))]
[Description("移动文档")]
public class MoveDocumentCommand : ICacheInvalidatorRequest<Result<bool>>
{
    /// <summary>
    /// 唯一标识
    /// </summary>
    [Description("唯一标识")]
    public long DocumentId { get; set; }

    /// <summary>
    /// 父级
    /// </summary>
    [Description("父级")]
    public long? ParentId { get; set; }

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
public class UpdateDocumentCommandHandler : IRequestHandler<MoveDocumentCommand, Result<long>>
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
    public async Task<Result<bool>> Handle(MoveDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await _context.Documents
           .SingleOrDefaultAsync(x => x.Id == request.DocumentId && x.ConcurrencyStamp == request.ConcurrencyStamp, cancellationToken)
           ?? throw new NotFoundException($"数据【{request.DocumentId}】未找到");

        document.ParentId = request.ParentId == null ? 1 : request.ParentId;
        document = _mapper.Map(request, document);
        //Document.AddDomainEvent(new UpdatedEvent<Document>(Document));
        _context.Documents.Update(document);
        var success = await _context.SaveChangesAsync(cancellationToken) > 0;
        return await Result<bool>.SuccessOrFailureAsync(success, success, new string[] { "操作失败" });
    }
}
