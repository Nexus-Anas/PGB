using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBannedUserInfoRepository
{
    Task<BannedUserInfo?> Find(int user_id);
    Task<bool> AddBannedUserInfos(BannedUserInfo bannedUserInfo);
}
