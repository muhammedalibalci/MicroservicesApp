using CatalogService.CQRS.Commands.DeleteCatalog;
using CatalogService.CQRS.Queires.GetCatalogById;

namespace CatalogService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCatalogById([FromQuery] GetCatalogByIdQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllCatalog([FromQuery] GetAllCatalogQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCatalog([FromBody] CreateCatalogCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCatalog([FromBody] UpdateCatalogCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCatalog([FromQuery] DeleteCatalogCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

}
