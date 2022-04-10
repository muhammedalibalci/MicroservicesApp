namespace BasketService.CQRS.Commands.Checkout;

public class CheckoutHandler : IRequestHandler<CheckoutCommand, bool>
{
    private readonly BasketContext _context;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<CheckoutHandler> _logger;

    public CheckoutHandler(BasketContext context, IMapper mapper, ILogger<CheckoutHandler> logger, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> Handle(CheckoutCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checkout operation is starting");

        var entity = await _context.CustomerBaskets.Include(x=>x.Items).SingleOrDefaultAsync(x => x.BuyerId == "1");

        if (entity == null) return false;

        var items = _mapper.Map<List<BasketItemMessage>>(entity.Items);

        var @event = new OrderCreatedEvent
        {
            BuyerId = entity.BuyerId,
            Items = items
        };

        await _publishEndpoint.Publish(@event);

        return true;
    }
}
