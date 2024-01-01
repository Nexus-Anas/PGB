using Authentication.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Authentication.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOrderController : ControllerBase
{
    private readonly HttpClient _http;
    public UserOrderController(IHttpClientFactory httpClientFactory)
        => _http = httpClientFactory.CreateClient();




    [HttpPost("Send Order")]
    public async Task<IActionResult> SendOrder([FromBody] UserOrder order)
    {
        var response = await SendOrderToHandlerApi(order);
        return Ok(response);
    }

    [HttpPost("Return Order")]
    public async Task<IActionResult> ReturnOrder([FromBody] UserOrder order)
    {
        var response = await ReturnOrderToHandlerApi(order);
        return Ok(response);
    }


    private async Task<string> SendOrderToHandlerApi(UserOrder order)
    {
        var handlerApiUrl = "https://localhost:44364/gateway/BookOrder/RegisterBookOrder";
        var response = await _http.PostAsJsonAsync(handlerApiUrl, order);
        return await response.Content.ReadAsStringAsync();
    }

    private async Task<string> ReturnOrderToHandlerApi(UserOrder order)
    {
        var handlerApiUrl = "https://localhost:44364/gateway/BookOrder/ReturnBookOrder";
        var response = await _http.PostAsJsonAsync(handlerApiUrl, order);
        return await response.Content.ReadAsStringAsync();
    }
}