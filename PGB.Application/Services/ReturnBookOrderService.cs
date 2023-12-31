using PGB.Application.DTOs.BookDTO;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Application.Interfaces;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;

namespace PGB.Application.Services;

public class ReturnBookOrderService : IReturnBookOrderService
{
    private readonly IUnitOfWork _uow;
    private readonly IUserRestrictionHandler _userRestrictionHandler;

    public ReturnBookOrderService(IUnitOfWork uow, IUserRestrictionHandler userRestrictionHandler)
    {
        _uow = uow;
        _userRestrictionHandler = userRestrictionHandler;
    }




    public async Task<(IEnumerable<BookGetDTO>, string)> ReturnBookOrder(BookOrderPutDTO bookOrderPutDTO)
    {
        if (await _userRestrictionHandler.IsUserRestricted(bookOrderPutDTO.UserId))
            return (Enumerable.Empty<BookGetDTO>(), CustomMessage.UserRestricted());

        var bookOrder = await _uow.BookOrderRepository.FindLastBookOrder(bookOrderPutDTO.UserId);

        if (bookOrder is null)
            return (Enumerable.Empty<BookGetDTO>(), CustomMessage.NoBookOrderFound());

        if (bookOrder.BooksReturnedInExpectedDate())
            return (bookOrderPutDTO.Books, CustomMessage.InformBookReturned());

        await _userRestrictionHandler.HandleLateReturn(bookOrderPutDTO.UserId);
        return (Enumerable.Empty<BookGetDTO>(), CustomMessage.UserBanned());
    }
}