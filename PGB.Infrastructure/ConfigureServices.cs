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

        services.AddDbContext<IDBC, SqlServerDBC>(op => op.UseSqlServer(mssql_con));
        //services.AddDbContext<IDBC, MySqlDBC>(op => op.UseMySql(mysql_con, ServerVersion.Parse("10.4.28-mariadb")));

        //Repositories
        services.AddScoped<IBannedUserInfoRepository, BannedUserInfoRepository>();
        services.AddScoped<IBannedUserRepository, BannedUserRepository>();
        services.AddScoped<IBookOrderRepository, BookOrderRepository>();
        services.AddScoped<IUserOrderRepository, UserOrderRepository>();
        services.AddScoped<IUserPenaltyRepository, UserPenaltyRepository>();

        return services;
    }
}
