namespace CatalogService.CQRS.Queires.GetOrderById;

public class GetOrderByIdQuery : IRequest<Order>
{
    public int Id { get; set; }
}
