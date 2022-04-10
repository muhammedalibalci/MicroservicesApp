namespace OrderService.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly OrderContext _context;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderCreatedEventConsumer(OrderContext context, IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var order = new Order
            {
                BuyerId = context.Message.BuyerId,
                OrderDate = DateTime.UtcNow,
                OrderStatusId = 1,
            };

            order.OrderItems = new List<OrderItem>();

            foreach (var orderItem in context.Message.Items)
            {
                order.OrderItems.Add(new OrderItem { ProductId = orderItem.ProductId,Count = orderItem.Quantity});
            }

            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
