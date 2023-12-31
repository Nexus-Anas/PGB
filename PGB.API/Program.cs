using PGB.API.InterfacesApi;
using PGB.Application;
using PGB.Infrastructure;
using Polly;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


//Target API address
var apiAddress = new Uri("https://localhost:44349/api/");


//Polly
IAsyncPolicy<HttpResponseMessage> retryPolicy = 
    Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(10);
builder.Services.AddSingleton(retryPolicy);


//Http client
var httpClient = new HttpClient { BaseAddress = apiAddress };
builder.Services.AddSingleton(httpClient);


//Refit
builder.Services.AddHttpClient<IBookApi>(http => http.BaseAddress = apiAddress)
    .AddTypedClient(RestService.For<IBookApi>);




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



//test bdd: spekflow