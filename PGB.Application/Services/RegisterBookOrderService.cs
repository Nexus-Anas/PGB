using AutoMapper;
using PGB.Application.DTOs.BookDTO;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Application.Interfaces;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using System.Net.WebSockets;

namespace PGB.Application.Services;

public class RegisterBookOrderService : IRegisterBookOrderService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;
    private readonly IUserOrderHandler _userOrderHandler;
    private readonly IUserRestrictionHandler _userRestrictionHandler;

    public RegisterBookOrderService(IMapper mapper, IUnitOfWork uow, IUserOrderHandler userOrderHandler, IUserRestrictionHandler userRestrictionHandler)
    {
        _mapper = mapper;
        _uow = uow;
        _userOrderHandler = userOrderHandler;
        _userRestrictionHandler = userRestrictionHandler;
    }





    public async Task<(IEnumerable<BookGetDTO>, string)> RegisterBookOrder(BookOrderPostDTO bookOrderPostDTO)
    {
        if (await _userRestrictionHandler.IsUserRestricted(bookOrderPostDTO.UserId))
            return (Enumerable.Empty<BookGetDTO>(), CustomMessage.UserRestricted());

        var bookOrder = _mapper.Map<BookOrder>(bookOrderPostDTO);

        var userOrder = await _uow.UserOrderRepository.Find(bookOrder.UserId);

        if (userOrder is not null && !userOrder.CanPlaceOrder())
            return (Enumerable.Empty<BookGetDTO>(), CustomMessage.MaxOrderReached());

        return await _userOrderHandler.SaveUserOrder(bookOrder)
            ? (bookOrderPostDTO.Books, CustomMessage.InformBookOrder())
            : (Enumerable.Empty<BookGetDTO>(), CustomMessage.ErrorOccurred());
    }
}
