namespace CatalogService.CQRS.Commands.DeleteCatalog;

public class DeleteCatalogCommand : IRequest<bool>
{
    public int Id { get; set; }
}
