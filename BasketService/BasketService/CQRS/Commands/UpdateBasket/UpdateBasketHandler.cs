namespace CatalogService.CQRS.Commands.UpdateBasket;

public class UpdateBasketHandler : IRequestHandler<UpdateBasketCommand, bool>
{
    private readonly BasketContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateBasketHandler> _logger;

    public UpdateBasketHandler(BasketContext context, ILogger<UpdateBasketHandler> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Update basket operation is starting");

        var entity = await _context.CustomerBaskets.SingleOrDefaultAsync(x => x.BuyerId == request.BuyerId);

        if (entity == null)
        {
            _logger.LogInformation($"No basket for user id: {request.BuyerId}");
            return false;
        }

        var source = _mapper.Map(request, entity);

        _context.CustomerBaskets.Update(source);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"Update basket operation was completed successfully. Updated basket for user id :{entity.BuyerId}");

        return true;
    }
}
