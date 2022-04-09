namespace CatalogService.CQRS.Queires.GetCatalogById;

public class GetCatalogByIdQuery : IRequest<CatalogItem>
{
    public int Id { get; set; }
}
