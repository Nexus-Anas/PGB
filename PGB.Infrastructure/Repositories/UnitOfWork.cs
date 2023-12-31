using PGB.Application.IRepositories;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDBC _db;
    public IBookOrderRepository BookOrderRepository { get; }
    public IUserOrderRepository UserOrderRepository { get; }
    public IBannedUserRepository BannedUserRepository { get; }
    public IBannedUserInfoRepository BannedUserInfoRepository { get; }
    public IUserPenaltyRepository UserPenaltyRepository { get; }


    public UnitOfWork(
        IDBC db,
        IBookOrderRepository bookOrderRepository,
        IUserOrderRepository userOrderRepository,
        IBannedUserRepository bannedUserRepository,
        IBannedUserInfoRepository bannedUserInfoRepository,
        IUserPenaltyRepository userPenaltyRepository)
    {
        _db = db;
        BookOrderRepository = bookOrderRepository;
        UserOrderRepository = userOrderRepository;
        BannedUserRepository = bannedUserRepository;
        BannedUserInfoRepository = bannedUserInfoRepository;
        UserPenaltyRepository = userPenaltyRepository;
    }


    public async Task<int> CommitAsync()
        => await _db.SaveChangesAsync();

    public void Dispose()
        => _db.Dispose();
}
