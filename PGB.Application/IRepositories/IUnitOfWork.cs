namespace PGB.Application.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IBookOrderRepository BookOrderRepository { get; }
    IUserOrderRepository UserOrderRepository { get; }
    IBannedUserRepository BannedUserRepository { get; }
    IBannedUserInfoRepository BannedUserInfoRepository { get; }
    IUserPenaltyRepository UserPenaltyRepository { get; }

    Task<int> CommitAsync();
}
