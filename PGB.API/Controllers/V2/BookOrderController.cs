using Microsoft.AspNetCore.Mvc;
using PGB.Application.BookOrders.Commands;
using PGB.Application.DTOs.BookDTO;
using Serilog;

namespace PGB.API.Controllers.V2;

[Route("api/[controller]")]
[ApiController]
public class BookOrderController : ApiControllerBase
{
    private IEnumerable<BookGetDTO>? _orderedBooks;
    private IEnumerable<BookGetDTO>? _returnedBooks;
    private readonly ILogger<BookOrderController> _logger;

    public BookOrderController(ILogger<BookOrderController> logger)
    {
        _logger = logger;
        _orderedBooks = Enumerable.Empty<BookGetDTO>();
        _returnedBooks = Enumerable.Empty<BookGetDTO>();
    }

    [HttpPost("RegisterBookOrder")]
    public async Task<IActionResult> RegisterBookOrder(RegisterBookOrderCommand cmd)
    {
        var result = await Mediator.Send(cmd);
        var msg = result.Msg;
        Log.Information($"RegisterBookOrder function invoked.\nMessage status:\n{msg}");
        _orderedBooks = result.Books;
        return Ok(msg);
    }


    [HttpPost("ReturnBookOrder")]
    public async Task<IActionResult> ReturnBookOrder(ReturnBookOrderCommand cmd)
    {
        var result = await Mediator.Send(cmd);
        var msg = result.Msg;
        Log.Information($"ReturnBookOrder function invoked.\nMessage status:\n{msg}");
        _returnedBooks = result.Books;
        return Ok(msg);
    }



    [HttpGet("GetOrderedBooks")]
    public async Task<IActionResult> GetOrderedBooks()
    {
        return Ok(_orderedBooks);
    }


    [HttpGet("GetReturnedBooks")]
    public async Task<IActionResult> GetReturnedBooks()
    {
        return Ok(_returnedBooks);
    }
}
