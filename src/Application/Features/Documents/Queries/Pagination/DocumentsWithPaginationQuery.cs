using Application.Common.Extensions;
using Application.Features.Documents.Specifications;
using Application.Features.Documents.Caching;
using Application.Features.Documents.DTOs;
using Domain.Repositories;

namespace Application.Features.Documents.Queries.Pagination;

/// <summary>
/// 文档分页查询
/// </summary>
[Description("分页查询文档数据")]
public class DocumentsWithPaginationQuery : DocumentAdvancedFilter, ICacheableRequest<Result<PaginatedData<DocumentDto>>>
{
    public override string ToString()
    {
        return
            $"Search:{Keyword},Name:{Name},ParentId:{ParentId},DocumentId:{DocumentId},SortDirection:{SortDirection},OrderBy:{OrderBy},{PageNumber},{PageSize}";
    }
    [JsonIgnore]
    public DocumentAdvancedPaginationSpec Specification => new DocumentAdvancedPaginationSpec(this);
    [JsonIgnore]
    public string CacheKey => DocumentCacheKey.GetPaginationCacheKey($"{this}");
    [JsonIgnore]
    public MemoryCacheEntryOptions? Options => DocumentCacheKey.MemoryCacheEntryOptions;
}

/// <summary>
/// 处理程序
/// </summary>
public class DocumentsWithPaginationQueryHandler :
IRequestHandler<DocumentsWithPaginationQuery, Result<PaginatedData<DocumentDto>>>
{
    private readonly IApplicationDbContext _context;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    public DocumentsWithPaginationQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IRoleRepository roleRepository)
    {
        _context = context;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    /// <summary>
    /// 业务逻辑
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="cancellationToken">取消标记</param>
    /// <returns>返回用户分页数据</returns>
    public async Task<Result<PaginatedData<DocumentDto>>> Handle(
        DocumentsWithPaginationQuery request, 
        CancellationToken cancellationToken)
    {
        var documents = await _context.Documents
            .OrderBy($"{request.OrderBy} {request.SortDirection}")
            .ProjectToPaginatedDataAsync<Document, DocumentDto>(
            request.Specification, 
            request.PageNumber, 
            request.PageSize, 
            _mapper.ConfigurationProvider, 
            cancellationToken);

        return await Result<PaginatedData<DocumentDto>>.SuccessAsync(documents);
    }
}
