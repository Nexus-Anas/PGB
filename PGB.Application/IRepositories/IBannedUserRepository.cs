using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBannedUserRepository
{
    Task<BannedUser?> Find(int user_id);
    Task<bool> Ban(BannedUser banned);
    Task<bool> Unban(BannedUser banned);
}