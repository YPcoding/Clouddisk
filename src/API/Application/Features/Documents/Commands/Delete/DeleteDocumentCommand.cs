using Application.Features.Documents.Caching;

namespace Application.Features.Documents.Commands.Delete;

/// <summary>
/// 删除文档
/// </summary>
[Description("删除文档")]
public class DeleteDocumentCommand : ICacheInvalidatorRequest<Result<bool>>
{
    /// <summary>
    /// 唯一标识
    /// </summary>
    [Description("唯一标识")]
    public List<long> DocumentIds { get; set; }

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
public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, Result<bool>>
{
    private readonly IApplicationDbContext _context;

    public DeleteDocumentCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 业务逻辑
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="cancellationToken">取消标记</param>
    /// <returns>返回处理结果</returns>
    public async Task<Result<bool>> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        var documentsToDelete = await _context.Documents
            .Where(x => request.DocumentIds.Contains(x.Id))
            .ToListAsync();

        if (documentsToDelete.Any())
        {
            _context.Documents.RemoveRange(documentsToDelete);
            var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;
            return await Result<bool>.SuccessOrFailureAsync(isSuccess, isSuccess, new string[] { "操作失败" });
        }

        return await Result<bool>.FailureAsync(new string[] { "没有找到需要删除的数据" });
    }
}