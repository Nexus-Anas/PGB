using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBannedUserRepository
{
    Task<bool> BanAsync(BannedUser banned);
    Task UnbanExpiredUsersAsync();
}
