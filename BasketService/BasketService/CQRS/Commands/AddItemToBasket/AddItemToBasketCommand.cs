namespace CatalogService.CQRS.Commands.AddItemToBasket;
public class AddItemToBasketCommand : IRequest<bool>
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }
}
