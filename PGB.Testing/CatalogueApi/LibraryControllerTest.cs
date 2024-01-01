using Catalogue.Api.Controllers;
using Catalogue.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace PGB.Testing.CatalogueApi;

public class LibraryControllerTest
{
    [Fact]
    public void BooksExists()
    {
        // Arrange
        var controller = new LibraryController();
        List<Book> books = new()
        {
            new Book{ BookId = 20, Quantity = 2 },
            new Book{ BookId = 21, Quantity = 1 },
            new Book{ BookId = 22, Quantity = 3 },
        };

        // Act
        var result = controller.GetOrderedBooks(books);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void BooksDoesNotExists()
    {
        // Arrange
        var controller = new LibraryController();
        List<Book> books = new();

        // Act
        var result = controller.GetOrderedBooks(books);

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.InternalServerError, (result as ObjectResult).StatusCode);
    }
}