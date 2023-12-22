using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IUserOrderRepository
{
    Task<bool> PostOrderBlockAsync(UserOrder userOrder);
    Task<bool> BlockOrder(int id);
    Task<int> IncrementOrderBlockAsync(int id);
    Task<bool> RemoveOrderBlockAsync(int id);
    Task<UserOrder?> GetAsync(int id);
}
