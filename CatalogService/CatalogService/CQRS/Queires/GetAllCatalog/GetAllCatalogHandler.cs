namespace CatalogService.CQRS.Queires.GetAllCatalog;
public class GetAllCatalogHandler : IRequestHandler<GetAllCatalogQuery, List<CatalogItem>>
{
    private readonly CatalogContext _context;

    public GetAllCatalogHandler(CatalogContext context)
    {
        _context = context;
    }

    public async Task<List<CatalogItem>> Handle(GetAllCatalogQuery request, CancellationToken cancellationToken)
    {
        return await _context.CatalogItems.ToListAsync(cancellationToken);
    }
}
