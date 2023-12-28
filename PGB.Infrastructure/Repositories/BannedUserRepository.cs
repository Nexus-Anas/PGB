using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class BannedUserRepository : IBannedUserRepository
{
    private readonly IDBC _db;
    public BannedUserRepository(IDBC db) => _db = db;




    public async Task<BannedUser?> Find(int user_id)
    {
        var user = await _db.BannedUsers.SingleOrDefaultAsync(x => x.UserId == user_id);
        return user;
    }

    public async Task<bool> Ban(BannedUser bannedUser)
    {
        await _db.BannedUsers.AddAsync(bannedUser);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Unban(BannedUser banned)
    {
        var user  = await Find(banned.UserId);
        if (user is not null)
        {
            _db.BannedUsers.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
