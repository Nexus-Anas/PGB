using Microsoft.EntityFrameworkCore;
using PGB.Domain.Entities;

namespace PGB.Infrastructure.Data;

public class SqlServerDBC : DbContext, IDBC
{
    public SqlServerDBC(DbContextOptions<SqlServerDBC> options) : base(options)
    {

    }


    public DbSet<BannedUserInfo> BannedUserInfos { get; set; }
    public DbSet<BannedUser> BannedUsers { get; set; }
    public DbSet<BookOrder> BookOrders { get; set; }
    public DbSet<UserPenalty> UserPenalties { get; set; }
    public DbSet<UserOrder> UserOrders { get; set; }

    public async Task<int> SaveChangesAsync()
        => await base.SaveChangesAsync();
}
