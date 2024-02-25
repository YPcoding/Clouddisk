using Ardalis.Specification;

namespace Application.Features.Documents.Specifications;

public class DocumentAdvancedPaginationSpec : Specification<Document>
{
    public DocumentAdvancedPaginationSpec(DocumentAdvancedFilter filter)
    {
        Query
             .Where(x => x.ParentId == filter.ParentId, filter.ParentId.HasValue)
             .Where(x => x.Id == filter.DocumentId, filter.DocumentId.HasValue)
             .Where(x => x.Name!.Contains(filter.Keyword!), !filter.Keyword!.IsNullOrWhiteSpace())
             .Where(x => x.Name == filter.Name, !filter.Name!.IsNullOrWhiteSpace());
    }
}