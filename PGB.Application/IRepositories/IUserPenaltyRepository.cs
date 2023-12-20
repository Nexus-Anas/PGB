using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IUserPenaltyRepository
{
    Task<bool> PostAsync(UserPenalty userPenalty);
    Task<bool> Remove(int id);
}