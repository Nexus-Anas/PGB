using Microsoft.AspNetCore.Diagnostics;
using PGB.API.InterfacesApi;
using PGB.API.Middlewares;
using PGB.Application;
using PGB.Infrastructure;
using Polly;
using Refit;
using Serilog;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//Serilog setup
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/app_logs.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

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

app.UseExceptionHandler(op => op.Run(
    async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var ex = context.Features.Get<IExceptionHandlerFeature>();
        if (ex is not null)
            await context.Response.WriteAsync(ex.Error.Message);
    }));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



//test bdd: spekflow