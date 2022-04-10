using Shared.Domain;

namespace Shared.OrderEvents;
public class OrderCreatedEvent
{
    public string BuyerId { get; set; }

    public List<BasketItemMessage> Items { get; set; } = new List<BasketItemMessage>();
}
