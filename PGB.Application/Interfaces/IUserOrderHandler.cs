using PGB.Domain.Entities;

namespace PGB.Application.Interfaces;

public interface IUserOrderHandler
{
    Task<bool> SaveUserOrder(BookOrder bookOrder);
    //Task<bool> RegisterExistingUserOrder(BookOrder bookOrder);
}