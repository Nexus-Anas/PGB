using Microsoft.EntityFrameworkCore;
using PGB.Domain.Entities;

namespace PGB.Infrastructure.Data;

public class MYSQL_DBC : DbContext, IDBC
{
    public MYSQL_DBC(DbContextOptions<MYSQL_DBC> options) : base(options)
    {

    }


    public DbSet<BannedUserInfo> BannedUserInfos { get; set; }
    public DbSet<BannedUser> BannedUsers { get; set; }
    public DbSet<BookOrder> BookOrders { get; set; }
    public DbSet<UserPenalty> UserPenalties { get; set; }
    public DbSet<UserOrder> UserOrders { get; set; }

    public async Task<int> SaveChangesAsync()
        => await base.SaveChangesAsync();

    public async Task Dispose()
        => await base.DisposeAsync();
}