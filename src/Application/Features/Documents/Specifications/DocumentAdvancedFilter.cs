namespace Application.Features.Documents.Specifications;

/// <summary>
/// 高级查询
/// </summary>
public class DocumentAdvancedFilter : PaginationFilter
{
    /// <summary>
    /// 文档
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 文档唯一标识
    /// </summary>
    public long? DocumentId { get; set; }

    /// <summary>
    /// 父级
    /// </summary>
    public long? ParentId { get; set;}
}