﻿using Microsoft.EntityFrameworkCore;
using PGB.Domain.Entities;

namespace PGB.Infrastructure.Data;

public class MySqlDBC : DbContext, IDBC
{
    public MySqlDBC(DbContextOptions<MySqlDBC> options) : base(options)
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