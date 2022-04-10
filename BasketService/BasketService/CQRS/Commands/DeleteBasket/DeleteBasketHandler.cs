namespace CatalogService.CQRS.Commands.DeleteBasket;

public class DeleteBasketHandler : IRequestHandler<DeleteBasketCommand, bool>
{
    private readonly BasketContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteBasketHandler> _logger;

    public DeleteBasketHandler(BasketContext context, IMapper mapper, ILogger<DeleteBasketHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Delete basket operation is starting");

        var entity = await _context.BasketItems.SingleOrDefaultAsync(x=>x.Id == request.Id);

        if (entity == null)
        {
            _logger.LogInformation($"No basket for {request.Id} id");
            return false;
        }

        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"Delete basket operation was completed successfully. Deleted basket id :{entity.Id}");

        return true;
    }
}
