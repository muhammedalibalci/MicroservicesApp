namespace BasketService.Consumers;

public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
{
    private readonly BasketContext _context;

    public OrderCompletedEventConsumer(BasketContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
    {
        var basket = await _context.CustomerBaskets.SingleOrDefaultAsync(x => x.BuyerId == context.Message.BuyerId);

        if (basket is null) return;

        _context.Remove(basket);

        await _context.SaveChangesAsync();
    }
}
