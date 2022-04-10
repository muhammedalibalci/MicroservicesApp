namespace CatalogService.CQRS.Commands.UpdateBasket;

public class UpdateBasketCommand : IRequest<bool>
{
    public string BuyerId { get; set; }

    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
}
