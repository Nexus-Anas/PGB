using Microsoft.AspNetCore.Mvc;
using PGB.Application.BookOrders.Commands;
using PGB.Application.DTOs.BookDTO;
using Serilog;
using System.Net;

namespace PGB.API.Controllers.V2;

[Route("api/V2/[controller]")]
[ApiController]
public class BookOrderController : ApiControllerBase
{
    private readonly HttpClient _http;
    private readonly ILogger<BookOrderController> _logger;
    public BookOrderController(ILogger<BookOrderController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _http = httpClientFactory.CreateClient();
    }




    [HttpPost("RegisterBookOrder")]
    public async Task<IActionResult> RegisterBookOrder(RegisterBookOrderCommand cmd)
    {
        var (msg, books) = await Mediator.Send(cmd);
        Log.Information($"RegisterBookOrder function invoked.\nMessage status:\n{msg}");

        if (!books.Any())
            return NotFound(msg);

        var response = await GetBooksFromCatalogueApi(books);

        if (response == HttpStatusCode.OK)
            return Ok(msg);

        return Ok(response);
    }


    [HttpPost("ReturnBookOrder")]
    public async Task<IActionResult> ReturnBookOrder(ReturnBookOrderCommand cmd)
    {
        var (msg, books) = await Mediator.Send(cmd);
        Log.Information($"ReturnBookOrder function invoked.\nMessage status:\n{msg}");

        if (!books.Any())
            return NotFound(msg);

        var response = await ReturnBooksToCatalogueApi(books);

        if (response == HttpStatusCode.OK)
            return Ok(msg);

        return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, try again later");
    }



    private async Task<HttpStatusCode> GetBooksFromCatalogueApi(IEnumerable<BookGetDTO> books)
    {
        var catalogueApiUrl = "https://localhost:44361/api/Library/GetOrderedBooks";
        var response = await _http.PostAsJsonAsync(catalogueApiUrl, books);
        return response.StatusCode;
        //return await response.Content.ReadAsStringAsync();
    }

    private async Task<HttpStatusCode> ReturnBooksToCatalogueApi(IEnumerable<BookGetDTO> books)
    {
        var catalogueApiUrl = "https://localhost:44361/api/Library/GetReturnedBooks";
        var response = await _http.PostAsJsonAsync(catalogueApiUrl, books);
        return response.StatusCode;
    }
}
