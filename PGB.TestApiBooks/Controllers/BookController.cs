using Microsoft.AspNetCore.Mvc;
using PGB.TestApiBooks.Entities;
using System.Net;

namespace PGB.TestApiBooks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var books = new List<Book>()
        {
            new Book() { Id = 1, Name = "Man of Medan", Description = "Horror" },
            new Book() { Id = 2, Name = "The devil in me", Description = "Horror" },
            new Book() { Id = 3, Name = "House of Ashes", Description = "Horror" },
            new Book() { Id = 4, Name = "Little Hope", Description = "Horror" }
        };
        var book = books.Where(b => b.Id == id).Single();
        if (book.Id != 0)
        {
            return Ok(book);
        }
        return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong when getting the book.");
    }
}
