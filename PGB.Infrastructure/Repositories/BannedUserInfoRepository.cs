using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class BannedUserInfoRepository : IBannedUserInfoRepository
{
    private readonly IDBC _db;
    public BannedUserInfoRepository(IDBC db) => _db = db;




    public async Task<BannedUserInfo?> Find(int user_id)
    {
        var bannedUserInfo = await _db.BannedUserInfos.LastOrDefaultAsync(u => u.UserId == user_id);
        return bannedUserInfo;
    }

    public async Task<bool> AddBannedUserInfos(BannedUserInfo bannedUserInfo)
    {
        await _db.BannedUserInfos.AddAsync(bannedUserInfo);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(BannedUserInfo bannedUserInfo)
    {
        var userInfo = await Find(bannedUserInfo.UserId);
        if (userInfo is not null)
        {
            userInfo.BanUserForOneYear();
            await _db.SaveChangesAsync();
        }
        return true;
    }
}