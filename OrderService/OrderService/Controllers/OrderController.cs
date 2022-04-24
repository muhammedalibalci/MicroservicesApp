using CatalogService.CQRS.Queires.GetOrderById;
using Microsoft.AspNetCore.Authorization;
using Shared.Configurations;

namespace CatalogService.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles =Roles.ReadOrder)]
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
        try
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception e)
        {

            throw;
        }
    }
}
