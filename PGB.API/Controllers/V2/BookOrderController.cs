using Microsoft.AspNetCore.Mvc;
using PGB.Application.Models.BookOrder.Command.RegisterBookOrder;

namespace PGB.API.Controllers.V2;

[Route("api/[controller]")]
[ApiController]
public class BookOrderController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisterBookOrder(RegisterBookOrderCmd cmd)
    {
        var bookOrder = await Mediator.Send(cmd);
        return Ok(bookOrder);
    }
}
