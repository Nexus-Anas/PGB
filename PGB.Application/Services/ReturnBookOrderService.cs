using AutoMapper;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Application.Interfaces;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;

namespace PGB.Application.Services;

public class ReturnBookOrderService : IReturnBookOrderService
{
    private readonly IBookOrderRepository _bookOrderRepository;
    private readonly IBannedUserRepository _bannedUserRepository;
    private readonly IBannedUserInfoRepository _bannedUserInfoRepository;
    private readonly IUserPenaltyRepository _userPenaltyRepository;

    public ReturnBookOrderService(IBookOrderRepository bookOrderRepository, IBannedUserRepository bannedUserRepository, IBannedUserInfoRepository bannedUserInfoRepository, IUserPenaltyRepository userPenaltyRepository)
    {
        _bookOrderRepository = bookOrderRepository;
        _bannedUserRepository = bannedUserRepository;
        _bannedUserInfoRepository = bannedUserInfoRepository;
        _userPenaltyRepository = userPenaltyRepository;
    }




    public async Task<(bool, string)> ReturnBookOrder(BookOrderPutDTO bookOrderPutDTO)
    {
        int user_id = bookOrderPutDTO.UserId;

        if (await IsUserBanned(user_id))
            return (false, CustomMessage.UserRestricted(user_id));

        var bookOrder = await _bookOrderRepository.FindLastOrder(user_id);

        if (bookOrder is null)
            return (false, CustomMessage.NoBookOrderFound(user_id));

        if (BookReturnedInExpectedDate(bookOrderPutDTO, bookOrder))
            return (true, CustomMessage.InformBookReturned(user_id));

        await HandleLateReturn(user_id);
        return (false, CustomMessage.UserBanned(user_id));
    }


    private static bool BookReturnedInExpectedDate(BookOrderPutDTO bookOrderPutDTO, BookOrder bookOrder)
    {
        return bookOrderPutDTO.ReturnDate <= bookOrder.ExpectedReturnDate;
    }

    private async Task HandleLateReturn(int userId)
    {
        int userPenalties = await _userPenaltyRepository.CountPenalties(userId);

        if (userPenalties == 0)
        {
            await AddPenaltyAndBanUser(userId);
        }
        else if (userPenalties < Restriction.MaxPenaltyByTrimester)
        {
            await IncrementPenaltyAndCheckLimit(userId);
        }
    }

    private async Task AddPenaltyAndBanUser(int userId)
    {
        var bannedUserInfo = new BannedUserInfo
        {
            UserId = userId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(7)
        };

        await Task.WhenAll(
            _bannedUserRepository.Ban(new BannedUser { UserId = userId }),
            _bannedUserInfoRepository.AddBannedUserInfos(bannedUserInfo),
            _userPenaltyRepository.AddUserPenalty(new UserPenalty { UserId = userId, PenaltiesInCurrentTrimester = 1 })
        );
    }

    private async Task IncrementPenaltyAndCheckLimit(int userId)
    {
        int userPenaltyValue = await _userPenaltyRepository.IncrementUserPenalty(userId);

        if (userPenaltyValue == Restriction.MaxPenaltyByTrimester)
        {
            var bannedUserInfo = new BannedUserInfo
            {
                UserId = userId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7)
            };
            await Task.WhenAll(
            _bannedUserRepository.Ban(new BannedUser { UserId = userId }),
            _bannedUserInfoRepository.AddBannedUserInfos(bannedUserInfo),
            _bannedUserInfoRepository.Update(bannedUserInfo)
            );
        }
    }

    private async Task<bool> IsUserBanned(int userId)
    {
        var bannedUser = await _bannedUserRepository.Find(userId);
        return bannedUser is not null;
    }

}
