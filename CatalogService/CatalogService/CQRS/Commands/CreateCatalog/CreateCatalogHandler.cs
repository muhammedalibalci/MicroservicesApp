namespace CatalogService.CQRS.Commands.CreateCatalog;
public class CreateCatalogHandler : IRequestHandler<CreateCatalogCommand, bool>
{
    private readonly CatalogContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCatalogHandler> _logger;

    public CreateCatalogHandler(CatalogContext context, IMapper mapper, ILogger<CreateCatalogHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create catalog operation is starting");

        var entity = _mapper.Map<CatalogItem>(request);

        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"Create catalog operation was completed successfully. Created catalog id :{entity.Id}");

        return true;
    }
}
