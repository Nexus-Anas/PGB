using AutoMapper;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Application.Interfaces;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using System.Net.WebSockets;

namespace PGB.Application.Services;

public class RegisterBookOrderService : IRegisterBookOrderService
{
    private readonly IMapper _mapper;
    private readonly IBookOrderRepository _bookOrderRepository;
    private readonly IUserOrderRepository _userOrderRepository;
    private readonly IBannedUserRepository _bannedUserRepository;

    public RegisterBookOrderService(IMapper mapper, IBookOrderRepository bookOrderRepository, IUserOrderRepository userOrderRepository, IBannedUserRepository bannedUserRepository)
    {
        _mapper = mapper;
        _bookOrderRepository = bookOrderRepository;
        _userOrderRepository = userOrderRepository;
        _bannedUserRepository = bannedUserRepository;
    }




    public async Task<(bool, string)> RegisterBookOrder(BookOrderPostDTO bookOrderPostDTO)
    {
        var bookOrder = _mapper.Map<BookOrder>(bookOrderPostDTO);
        int user_id = bookOrder.UserId;

        if (await IsUserBanned(user_id))
            return (false, CustomMessage.UserRestricted(user_id));

        var user = await _userOrderRepository.Find(user_id);

        if (user is not null && user.OrdersInCurrentMonth == Restriction.MaxOrderByMonth)
            return (false, CustomMessage.MaxOrderReached(user_id));

        if (user is null)
            return (await RegisterNewUserOrder(bookOrder), CustomMessage.InformBookOrder(user_id));

        return (await RegisterExistingUserOrder(user, bookOrder), CustomMessage.InformBookOrder(user_id));
    }





    private async Task<bool> IsUserBanned(int userId)
    {
        var bannedUser = await _bannedUserRepository.Find(userId);
        return bannedUser is not null;
    }

    private async Task<bool> RegisterNewUserOrder(BookOrder bookOrder)
    {
        var userOrder = new UserOrder { UserId = bookOrder.UserId, OrdersInCurrentMonth = 1, EndDate = null };
        await _userOrderRepository.AddUserOrder(userOrder);

        return await RegisterBookOrderDetails(bookOrder);
    }

    private async Task<bool> RegisterExistingUserOrder(UserOrder user, BookOrder bookOrder)
    {
        int value = await _userOrderRepository.IncrementOrderInCurrentMonth(user.UserId);

        var bookOrderState = await RegisterBookOrderDetails(bookOrder);

        if (value == Restriction.MaxOrderByMonth)
        {
            var state = await _userOrderRepository.BlockUserOrder(user.UserId);
            return state;
        }

        return bookOrderState;
    }

    private async Task<bool> RegisterBookOrderDetails(BookOrder bookOrder)
    {
        bookOrder.OrderDate = DateTime.Now;
        bookOrder.ExpectedReturnDate = DateTime.Now.AddDays(7);
        bookOrder.ReturnDate = null;
        return await _bookOrderRepository.Add(bookOrder);
    }
}
