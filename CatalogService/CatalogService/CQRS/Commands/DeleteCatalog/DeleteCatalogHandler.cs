namespace CatalogService.CQRS.Commands.DeleteCatalog;

public class DeleteCatalogHandler : IRequestHandler<DeleteCatalogCommand, bool>
{
    private readonly CatalogContext _context;
    private readonly ILogger<DeleteCatalogHandler> _logger;

    public DeleteCatalogHandler(CatalogContext context, ILogger<DeleteCatalogHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Delete catalog operation is starting");

        var entity = await _context.CatalogItems.SingleOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
        {
            _logger.LogInformation($"No catalog for {request.Id} id");
            return false;
        }

        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"Delete catalog operation was completed successfully. Deleted catalog id :{entity.Id}");

        return true;
    }
}
