namespace Application.Features.Documents.Commands.Move;

public class MoveDocumentCommandValidator : AbstractValidator<MoveDocumentCommand>
{
    private readonly IApplicationDbContext _context;
    public MoveDocumentCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(v => v.ParentId)
            .MustAsync(BeValidMove).WithMessage($"非法移动");
    }

    /// <summary>
    /// 校验是否
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<bool> BeValidMove(MoveDocumentCommand command, long? parentId, CancellationToken cancellationToken)
    {
        if (command.DocumentId == parentId) return false;

        var parentDocument = await _context.Documents.FirstOrDefaultAsync(x => x.Id == parentId, cancellationToken);
        if (parentDocument == null) return false;
        
        return parentDocument.Extension == null;
    }
}
