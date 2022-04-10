namespace CatalogService.CQRS.Commands.DeleteBasket;

public class DeleteBasketCommand : IRequest<bool>
{
    public int Id{ get; set; }
}
