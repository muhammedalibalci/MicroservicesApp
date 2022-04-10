namespace CatalogService.CQRS.Queires.GetOrderById;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly OrderContext _context;
    private readonly ILogger<GetOrderByIdHandler> _logger;

    public GetOrderByIdHandler(OrderContext context, ILogger<GetOrderByIdHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Orders.SingleOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
        {
            _logger.LogInformation($"No order for {request.Id} id");
            return null;
        }

        return entity;
    }
}
