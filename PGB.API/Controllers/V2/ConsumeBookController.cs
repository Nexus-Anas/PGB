using Microsoft.AspNetCore.Mvc;
using PGB.API.InterfacesApi;
using PGB.API.ModelsApi;
using Polly;
using Refit;

namespace PGB.API.Controllers.V2;

[Route("api/V2/[controller]")]
[ApiController]
public class ConsumeBookController : ApiControllerBase
{
    private readonly IBookApi _bookApi;
    private readonly HttpClient _httpClient;
    private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;
    public ConsumeBookController(IBookApi bookApi, HttpClient httpClient, IAsyncPolicy<HttpResponseMessage> retryPolicy)
    {
        _bookApi = bookApi;
        _httpClient = httpClient;
        _retryPolicy = retryPolicy;
    }




    [HttpGet("Refit/{id}")]
    public async Task<IActionResult> GetWithRefit(int id)
    {
        try
        {

            var book = await _bookApi.GetBookAsync(id);
            return Ok(book);
        }
        catch (ApiException ex)
        {
            return StatusCode((int)ex.StatusCode, "The book service returned an error.");
        }
    }

    [HttpGet("HttpClient/{id}")]
    public async Task<IActionResult> GetWithHttpClient(int id)
    {
        var response = await _retryPolicy.ExecuteAsync(() => _httpClient.GetAsync($"Book/{id}"));

        if (response.IsSuccessStatusCode)
        {
            var book = await response.Content.ReadFromJsonAsync<Book>();
            return Ok(book);
        }

        return StatusCode((int)response.StatusCode, "The book service returned an error.");
    }
}
