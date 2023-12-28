using System.Net;
using System.Threading.Tasks;
using WireMock.Server;
using WireMock.Settings;
using Xunit;
using Flurl.Http.Testing;
using Microsoft.AspNetCore.Mvc;
using PGB.TestApiBooks.Controllers;
using HandlebarsDotNet.Decorators;
using PGB.TestApiBooks.Entities;

namespace PGB.Testing.TestApiBooks;

public class BookControllerTest
{
    [Fact]
    public void Get_ReturnsOkObjectResult_WhenBookExists()
    {
        // Arrange
        var controller = new BookController();
        var id = 1;

        // Act
        var result = controller.Get(id);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Get_ReturnsInternalServerErrorResult_WhenBookDoesNotExist()
    {
        // Arrange
        var controller = new BookController();
        var id = 0;

        // Act
        var result = controller.Get(id);

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)System.Net.HttpStatusCode.InternalServerError, (result as ObjectResult).StatusCode);
    }

    [Fact]
    public void Get_ReturnsCorrectBook_WhenBookExists()
    {
        // Arrange
        var controller = new BookController();
        var id = 1;
        var expectedBook = new Book() { Id = 1, Name = "Man of Medan", Description = "Horror" };

        // Act
        var result = controller.Get(id);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expectedBook, okResult.Value);
    }
}
