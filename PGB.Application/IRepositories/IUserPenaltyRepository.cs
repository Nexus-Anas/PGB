using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IUserPenaltyRepository
{
    Task<bool> PostPenaltyAsync(UserPenalty userPenalty);
    Task<bool> RemovePenaltyAsync(int user_id);
    Task<bool> IncrementPenaltyAsync(int user_id);
    Task<int> CountPenaltyAsync(int user_id);
}