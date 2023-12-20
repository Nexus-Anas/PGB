using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class UserPenaltyRepository : IUserPenaltyRepository
{
    private readonly IDBC _db;
    public UserPenaltyRepository(IDBC db) => _db = db;




    public async Task<bool> PostAsync(UserPenalty userPenalty)
    {
        await _db.userPenalties.AddAsync(userPenalty);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(int id)
    {
        var user = await _db.userPenalties.FirstOrDefaultAsync(u => u.UserId == id);

        if (user is not null)
        {
            _db.userPenalties.Remove(user);
            await _db.SaveChangesAsync();
        }
        return true;
    }
}