namespace CatalogService.CQRS.Commands.UpdateCatalog;

public class UpdateCatalogHandler : IRequestHandler<UpdateCatalogCommand, bool>
{
    private readonly CatalogContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCatalogHandler> _logger;

    public UpdateCatalogHandler(CatalogContext context, IMapper mapper, ILogger<UpdateCatalogHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Update catalog operation is starting");

        var entity = await _context.CatalogItems.SingleOrDefaultAsync(x=>x.Id == request.Id);

        if (entity == null)
        {
            _logger.LogInformation($"No catalog for {request.Id} id");
            return false;
        }

        var source = _mapper.Map(request, entity);

        _context.Update(source);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"Update catalog operation was completed successfully. Updated catalog id :{source.Id}");

        return true;
    }
}
