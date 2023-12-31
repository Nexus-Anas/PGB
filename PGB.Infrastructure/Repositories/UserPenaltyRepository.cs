using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class UserPenaltyRepository : IUserPenaltyRepository
{
    private readonly IDBC _db;
    public UserPenaltyRepository(IDBC db) => _db = db;




    public async Task<bool> AddUserPenalty(UserPenalty userPenalty)
    {
        await _db.UserPenalties.AddAsync(userPenalty);
        return true;
    }

    public async Task<bool> RemoveUserPenalty(int user_id)
    {
        var penalty = await _db.UserPenalties.FirstOrDefaultAsync(u => u.UserId == user_id);

        if (penalty is not null)
            _db.UserPenalties.Remove(penalty);

        return true;
    }

    public async Task<int> IncrementUserPenalty(int user_id)
    {
        int value = 0;
        var penalty = await _db.UserPenalties.FirstOrDefaultAsync(u => u.UserId == user_id);
        if (penalty is not null)
        {
            penalty.PenaltiesInCurrentTrimester++;
            value = penalty.PenaltiesInCurrentTrimester;
            await _db.SaveChangesAsync();
        }
        return value;
    }

    public async Task<int> CountPenalties(int user_id)
    {
        var penalty = await _db.UserPenalties.FirstOrDefaultAsync(u => u.UserId == user_id);
        return (penalty is not null) ? penalty.PenaltiesInCurrentTrimester : 0;
    }
}