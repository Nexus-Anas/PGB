using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using PGB.API.ModelsApi;

namespace PGB.API.Controllers.V1;

[Route("api/V1/[controller]")]
[ApiController]
public class BookConsumptionController : ApiControllerBase
{
    [HttpGet("Flurl/{id}")]
    public async Task<IActionResult> GetWithFlurl(int id)
    {
        string bookApiBaseUrl = "https://localhost:44349/api";
        try
        {
            var book = await $"{bookApiBaseUrl}/Book/{id}"
                .GetJsonAsync<Book>();

            return Ok(book);
        }
        catch (FlurlHttpException ex)
        {
            return StatusCode(ex.Call.Response.StatusCode, "The book service returned an error.");
        }
    }
}
