using PGB.Application.IRepositories;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDBC _db;
    public IBookOrderRepository BookOrderRepository { get; private set; }
    public IUserOrderRepository UserOrderRepository { get; private set; }
    public IBannedUserRepository BannedUserRepository { get; private set; }
    public IBannedUserInfoRepository BannedUserInfoRepository { get; private set; }
    public IUserPenaltyRepository UserPenaltyRepository { get; private set; }


    public UnitOfWork(IDBC db)
    {
        _db = db;
        BookOrderRepository = new BookOrderRepository(_db);
        UserOrderRepository = new UserOrderRepository(_db);
        BannedUserRepository = new BannedUserRepository(_db);
        BannedUserInfoRepository = new BannedUserInfoRepository(_db);
        UserPenaltyRepository = new UserPenaltyRepository(_db);
    }


    public async Task<int> CompleteAsync()
        => await _db.SaveChangesAsync();

    public void Dispose()
        => _db.Dispose();
}
