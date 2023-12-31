using PGB.Application.Interfaces;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;

namespace PGB.Application.Services;

public class UserOrderHandler : IUserOrderHandler
{
    private readonly IUnitOfWork _uow;
    public UserOrderHandler(IUnitOfWork uow) => _uow = uow;




    public async Task<bool> SaveUserOrder(BookOrder bookOrder)
    {
        var userOrder = await _uow.UserOrderRepository.Find(bookOrder.UserId);
        if (userOrder is not null)
        {
            userOrder.TryIncrementOrdersInCurrentMonth();
            userOrder.TryBlockUserOrdersForOneMonth();
            await _uow.UserOrderRepository.UpdateUserOrder(userOrder);
        }
        else
            await _uow.UserOrderRepository.AddUserOrder(new UserOrder(bookOrder.UserId));

        await _uow.BookOrderRepository.AddBookOrder(bookOrder);
        await _uow.CompleteAsync();
        return true;
    }
}