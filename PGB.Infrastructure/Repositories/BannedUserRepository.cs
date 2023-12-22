using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class BannedUserRepository : IBannedUserRepository
{
    private readonly IDBC _db;
    public BannedUserRepository(IDBC db) => _db = db;




    public async Task<bool> BanAsync(BannedUser bannedUser)
    {
        await _db.BannedUsers.AddAsync(bannedUser);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<BannedUser> GetAsync(int user_id)
    {
        var user = await _db.BannedUsers.FindAsync(user_id);
        return user;
    }

    public async Task<bool> UnbanAsync(BannedUser banned)
    {
        var user  = await GetAsync(banned.UserId);
        if (user is null)
            return false;
        _db.BannedUsers.Remove(user);
        return true;
    }

    //public async Task UnbanExpiredUsersAsync()
    //{
    //    //var bannedUsers = await _db.BannedUsers.ToListAsync();
    //    //foreach (var item in bannedUsers)
    //    //    _db.BannedUsers.Remove(item);
    //    //await _db.SaveChangesAsync();
    //}
}
