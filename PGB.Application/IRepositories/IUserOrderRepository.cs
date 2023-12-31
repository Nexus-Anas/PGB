using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IUserOrderRepository
{
    Task<UserOrder?> Find(int user_id);
    Task<bool> AddUserOrder(UserOrder userOrder);
    Task<bool> RemoveUserOrder(int user_id);
    Task UpdateUserOrder(UserOrder userOrder);
    //Task<bool> BlockUserOrder(int user_id);
    //Task<int> IncrementOrderInCurrentMonth(int user_id);
}