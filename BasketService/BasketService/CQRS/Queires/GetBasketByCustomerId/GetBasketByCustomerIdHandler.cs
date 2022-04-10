namespace CatalogService.CQRS.Queires.GetBasketByCustomerId;

public class GetBasketByCustomerIdHandler : IRequestHandler<GetBasketByCustomerIdQuery, BasketItem>
{
    private readonly BasketContext _context;
    private readonly ILogger<GetBasketByCustomerIdHandler> _logger;

    public GetBasketByCustomerIdHandler(BasketContext context, ILogger<GetBasketByCustomerIdHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<BasketItem?> Handle(GetBasketByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.BasketItems.SingleOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
        {
            _logger.LogInformation($"No basket for {request.Id} id");
            return null;
        }

        return entity;
    }
}
