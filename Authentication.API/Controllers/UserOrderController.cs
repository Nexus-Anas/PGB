using Authentication.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOrderController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var books = new List<Book>()
        {
            new Book() { BookId = 1, Quantity = 1},
            new Book() { BookId = 5, Quantity = 2},
            new Book() { BookId = 11, Quantity = 1}
        };
        var userOrder = new UserOrder { UserId = id, Books = books };

        return Ok(userOrder);
    }
}
