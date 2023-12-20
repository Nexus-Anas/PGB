using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class BannedUserInfoRepository : IBannedUserInfoRepository
{
    private readonly IDBC _db;
    public BannedUserInfoRepository(IDBC db) => _db = db;




    public async Task<bool> PostAsync(BannedUserInfo bannedUserInfo)
    {
        await _db.BannedUserInfos.AddAsync(bannedUserInfo);
        await _db.SaveChangesAsync();
        return true;
    }
}
