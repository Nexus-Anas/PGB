using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class UserPenaltyRepository : IUserPenaltyRepository
{
    private readonly IDBC _db;
    public UserPenaltyRepository(IDBC db) => _db = db;

    public async Task<int> CountPenaltyAsync(int user_id)
    {
        var user = await _db.UserPenalties.FindAsync(user_id);
        if (user is null)
            return 0;
        return user.PenaltiesInCurrentTrimester;
    }

    public async Task<bool> IncrementPenaltyAsync(int user_id)
    {
        var penalty = await _db.UserPenalties.FindAsync(user_id);
        penalty.PenaltiesInCurrentTrimester++;
        return true;
    }

    public async Task<bool> PostPenaltyAsync(UserPenalty userPenalty)
    {
        await _db.UserPenalties.AddAsync(userPenalty);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemovePenaltyAsync(int user_id)
    {
        var user = await _db.UserPenalties.FirstOrDefaultAsync(u => u.UserId == user_id);

        if (user is not null)
        {
            _db.UserPenalties.Remove(user);
            await _db.SaveChangesAsync();
        }
        return true;
    }
}