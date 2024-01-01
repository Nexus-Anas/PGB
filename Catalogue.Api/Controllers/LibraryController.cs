using Catalogue.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryController : ControllerBase
{
    [HttpPost("GetOrderedBooks")]
    public IActionResult GetOrderedBooks(IEnumerable<Book> books)
    {
        return books.Any() ? Ok() : NotFound();
    }

    [HttpPost("GetReturnedBooks")]
    public IActionResult GetReturnedBooks(IEnumerable<Book> books)
    {
        return books.Any() ? Ok() : NotFound();
    }
}
