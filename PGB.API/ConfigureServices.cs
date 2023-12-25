using PGB.API.InterfacesApi;
using PGB.Application.Interfaces;
using PGB.Application.Mapping;
using PGB.Application.Services;
using Polly;
using Refit;
using System.Reflection;

namespace PGB.API;

public static class ConfigureServices
{
    public static IServiceCollection AddHttpClientServices(this IServiceCollection services)
    {

        //Polly
        IAsyncPolicy<HttpResponseMessage> retryPolicy =
            Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .RetryAsync(10);
        services.AddSingleton(retryPolicy);

        //Http client
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:44349/api/")
        };
        services.AddSingleton(httpClient);


        //Refit
        services.AddHttpClient<IBookApi>(http =>
        {
            http.BaseAddress = new Uri("https://localhost:44349/api");
        })
            .AddTypedClient(RestService.For<IBookApi>);



        return services;
    }
}