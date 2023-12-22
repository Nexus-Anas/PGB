using PGB.Domain.Entities;

namespace PGB.Application.Interfaces;

public interface IService
{
    Task<bool> SaveBookOrder(BookOrder bookOrder);
    Task<bool> ReturnBook(BookOrder bookReturn);
    Task<IEnumerable<Book>> OrderBooks(BookOrder bookOrder);
    Task<bool> SaveUserBanInfo(BannedUserInfo bannedUserInfo);
    Task<bool> BanUser(BannedUser banned);
    Task<bool> UnbanUser(BannedUser banned);
    Task<bool> AddPenalty(UserPenalty userPenalty);
    Task<bool> RemovePenalty(int id);
}
