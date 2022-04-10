namespace CatalogService.CQRS.Commands.AddItemToBasket;
public class AddItemToBasketHandler : IRequestHandler<AddItemToBasketCommand, bool>
{
    private readonly BasketContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<AddItemToBasketHandler> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddItemToBasketHandler(BasketContext context, IMapper mapper, ILogger<AddItemToBasketHandler> logger, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Add item to basket operation is starting");
     
        //var userId = _httpContextAccessor.HttpContext.User.Claims.First().Value;

        var entity = await _context.CustomerBaskets.SingleOrDefaultAsync(x => x.BuyerId == "1");
        
        if (entity is null)
        {
            entity = new CustomerBasket("1");
        }

        var basketItem = _mapper.Map<BasketItem>(request);

        entity.Items.Add(basketItem);

        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"Add item to basket operation was completed successfully. Added item id for customer id :{entity.BuyerId}");

        return true;
    }
}
