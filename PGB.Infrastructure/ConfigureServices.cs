using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //DbContext
        string? con = configuration.GetConnectionString("mssql_con");

        services.AddDbContext<IDBC, SqlServerDBC>(op => op.UseSqlServer(con));

        //Repositories


        return services;
    }
}
