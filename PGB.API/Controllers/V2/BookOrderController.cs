using Microsoft.AspNetCore.Mvc;
using PGB.Application.BookOrders.Commands;
using PGB.Application.DTOs.BookDTO;

namespace PGB.API.Controllers.V2;

[Route("api/[controller]")]
[ApiController]
public class BookOrderController : ApiControllerBase
{
    private IEnumerable<BookGetDTO>? _orderedBooks;
    private IEnumerable<BookGetDTO>? _returnedBooks;
    
    
    [HttpPost("RegisterBookOrder")]
    public async Task<IActionResult> RegisterBookOrder(RegisterBookOrderCommand cmd)
    {
        var result = await Mediator.Send(cmd);
        var message = result.Msg;
        _orderedBooks = result.Books;
        return Ok(message);
    }


    [HttpPost("ReturnBookOrder")]
    public async Task<IActionResult> ReturnBookOrder(ReturnBookOrderCommand cmd)
    {
        var result = await Mediator.Send(cmd);
        var message = result.Msg;
        _returnedBooks = result.Books;
        return Ok(message);
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
