using BasketService.CQRS.Commands.Checkout;

namespace CatalogService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBasketById([FromQuery] GetBasketByCustomerIdQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("addItemToBasket")]
    public async Task<IActionResult> AddItemToBasket([FromBody] AddItemToBasketCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout([FromBody] CheckoutCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket([FromQuery] DeleteBasketCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

}
