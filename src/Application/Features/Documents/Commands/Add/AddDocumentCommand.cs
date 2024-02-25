using Application.Features.Documents.Caching;
using Application.Features.Users.Caching;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Documents.Commands.Add;


/// <summary>
/// 新增文档
/// </summary>
[Map(typeof(Document))]
[Description("新增文档")]
public class AddDocumentCommand : ICacheInvalidatorRequest<Result<long>>
{
    /// <summary>
    /// 名称
    /// </summary>
    [Description("名称")]
    [Required(ErrorMessage = "名称是必填的")]
    public string Name { get; set; }

    /// <summary>
    /// 文件
    /// </summary>
    [Description("文件")]
    public IFormFile? File { get; set; }

    /// <summary>
    /// 父级ID
    /// </summary>
    [Description("父级")]
    public long? ParentId { get; set; } = null;

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
public class AddDocumentCommandHandler : IRequestHandler<AddDocumentCommand, Result<long>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AddDocumentCommandHandler(
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
    public async Task<Result<long>> Handle(AddDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = _mapper.Map<Document>(request);
        document.IsFileSaved = request.File == null ? true : null;
        document.ParentId = request.ParentId == null ? 1 : request.ParentId;
        if (request.File != null)
        {
            document.Name = request.File.FileName;
            document.AliasName = Guid.NewGuid();
            document.Extension = Path.GetExtension(document.Name);
            document.SizeByte = request.File.Length;
            document.Path = $"D:\\Documents\\{DateTime.Today.ToString("yyyyMMdd")}\\{document.AliasName}{document.Extension}";
        }
        document.AddDomainEvent(new CreatedEvent<Document>(document));
        await _context.Documents.AddAsync(document);
        var success = await _context.SaveChangesAsync(cancellationToken) > 0;
        return await Result<long>.SuccessOrFailureAsync(document.Id, success, new string[] { "操作失败" });
    }
}