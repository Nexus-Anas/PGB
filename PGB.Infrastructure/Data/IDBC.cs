using PGB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PGB.Infrastructure.Data;

public interface IDBC
{
    DbSet<BannedUserInfo> BannedUserInfos { get; set; }
    DbSet<BannedUser> BannedUsers { get; set; }
    DbSet<BookOrder> BookOrders { get; set; }
    DbSet<UserPenalty> UserPenalties { get; set; }
    DbSet<UserOrder> UserOrders { get; set; }

    Task<int> SaveChangesAsync();
    Task Dispose();
}