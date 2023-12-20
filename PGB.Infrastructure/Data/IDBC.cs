using PGB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PGB.Infrastructure.Data;

public interface IDBC
{
    DbSet<BannedUserInfo> BannedUserInfos { get; set; }
    DbSet<BannedUser> BannedUsers { get; set; }
    DbSet<BookOrder> BookOrders { get; set; }
    DbSet<BookReturn> BookReturns { get; set; }
    DbSet<UserPenalty> userPenalties { get; set; }

    Task<int> SaveChangesAsync();
}