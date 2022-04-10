namespace CatalogService.CQRS.Queires.GetBasketByCustomerId;

public class GetBasketByCustomerIdQuery : IRequest<BasketItem>
{
    public int Id { get; set; }
}
