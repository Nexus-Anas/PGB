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
        var bannedUserInfo = await _db.BannedUserInfos.OrderByDescending(x => x.Id).FirstOrDefaultAsync(u => u.UserId == user_id);
        return bannedUserInfo;
    }

    public async Task<bool> AddBannedUserInfos(BannedUserInfo bannedUserInfo)
    {
        await _db.BannedUserInfos.AddAsync(bannedUserInfo);
        return true;
    }
}