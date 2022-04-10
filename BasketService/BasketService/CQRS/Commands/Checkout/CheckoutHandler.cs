namespace BasketService.CQRS.Commands.Checkout;

public class CheckoutHandler : IRequestHandler<CheckoutCommand, bool>
{
    private readonly BasketContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CheckoutHandler> _logger;

    public CheckoutHandler(BasketContext context, IMapper mapper, ILogger<CheckoutHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(CheckoutCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checkout operation is starting");

        var entity = await _context.CustomerBaskets.SingleOrDefaultAsync(x => x.BuyerId == "1");

        if (entity == null) return false;

        // Trigger an event for order service

        return true;
    }
}
