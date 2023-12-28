using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IUserPenaltyRepository
{
    Task<bool> AddUserPenalty(UserPenalty userPenalty);
    Task<bool> RemoveUserPenalty(int user_id);
    Task<int> IncrementUserPenalty(int user_id);
    Task<int> CountPenalties(int user_id);
}