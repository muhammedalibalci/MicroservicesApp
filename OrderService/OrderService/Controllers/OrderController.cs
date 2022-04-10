using CatalogService.CQRS.Queires.GetOrderById;

namespace CatalogService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
