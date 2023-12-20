using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBannedUserInfoRepository
{
    Task<bool> PostAsync(BannedUserInfo bannedUserInfo);
}
