using Application.Common;
using Domain.Entities.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace Application.Features.Documents.EventHandlers;


public class DocumentCreatedEventHandler : INotificationHandler<CreatedEvent<Document>>
{
    private readonly ILogger<DocumentCreatedEventHandler> _logger;
    private readonly IHubContext<SignalRHub> _hubContext;
    private readonly IServiceProvider _serviceProvider; // 添加此字段


    public DocumentCreatedEventHandler(
        ILogger<DocumentCreatedEventHandler> logger,
        IHubContext<SignalRHub> hubContext,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _hubContext = hubContext;
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(CreatedEvent<Document> document, CancellationToken cancellationToken)
    {
        if (document.Entity.File == null || document.Entity.File.Length == 0) return;

        var directory = Path.GetDirectoryName(document.Entity.Path);
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory!);

        var filePath = Path.Combine(document.Entity.Path!);
        using var stream = new FileStream(filePath, FileMode.Create);
        await document.Entity.File.CopyToAsync(stream);

        bool isFileSaved = File.Exists(filePath);
        using var scope = _serviceProvider.CreateScope();
        var _context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        var documentEntity = await _context.Documents.SingleOrDefaultAsync(n => n.Id == document.Entity.Id);
        documentEntity!.IsFileSaved = isFileSaved;
        _context.Documents.Update(documentEntity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}