using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class BannedUserRepository : IBannedUserRepository
{
    private readonly IDBC _db;
    public BannedUserRepository(IDBC db) => _db = db;




    public async Task<bool> BanAsync(BannedUser banned)
    {
        await _db.BannedUsers.AddAsync(banned);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task UnbanExpiredUsersAsync()
    {
        var bannedUsers = await _db.BannedUsers.ToListAsync();
        foreach (var item in bannedUsers)
            _db.BannedUsers.Remove(item);
        await _db.SaveChangesAsync();
    }
}
