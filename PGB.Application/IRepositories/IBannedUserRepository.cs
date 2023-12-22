using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBannedUserRepository
{
    Task<bool> BanAsync(BannedUser banned);
    Task<bool> UnbanAsync(BannedUser banned);
    Task<BannedUser> GetAsync(int user_id);
}
