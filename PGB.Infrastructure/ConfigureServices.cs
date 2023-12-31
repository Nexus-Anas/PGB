using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PGB.Application.IRepositories;
using PGB.Infrastructure.Data;
using PGB.Infrastructure.Repositories;

namespace PGB.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //DbContext
        string? mssql_con = configuration.GetConnectionString("mssql_con");
        string? mysql_con = configuration.GetConnectionString("mysql_con");

        services.AddDbContext<IDBC, MSSQL_DBC>(op => op.UseSqlServer(mssql_con));
        services.AddDbContext<IDBC, MYSQL_DBC>(op => op.UseMySql(mysql_con, ServerVersion.Parse("10.4.28-mariadb")));

        //Repositories
       services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
