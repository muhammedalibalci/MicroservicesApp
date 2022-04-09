namespace CatalogService.CQRS.Queires.GetCatalogById;

public class GetCatalogByIdHandler : IRequestHandler<GetCatalogByIdQuery, CatalogItem>
{
    private readonly CatalogContext _context;
    private readonly ILogger<GetCatalogByIdHandler> _logger;

    public GetCatalogByIdHandler(CatalogContext context, ILogger<GetCatalogByIdHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CatalogItem?> Handle(GetCatalogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.CatalogItems.SingleOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
        {
            _logger.LogInformation($"No catalog for {request.Id} id");
            return null;
        }

        return entity;
    }
}
