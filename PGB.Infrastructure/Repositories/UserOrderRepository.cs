using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class UserOrderRepository : IUserOrderRepository
{
    private readonly IDBC _db;
    public UserOrderRepository(IDBC db) => _db = db;




    public async Task<UserOrder?> Find(int user_id)
    {
        var userOrder = await _db.UserOrders.FirstOrDefaultAsync(x => x.UserId == user_id);
        return userOrder;
    }

    public async Task<bool> AddUserOrder(UserOrder userOrder)
    {
        await _db.UserOrders.AddAsync(userOrder);
        return true;
    }

    public async Task<bool> RemoveUserOrder(int user_id)
    {
        var user = await Find(user_id);

        if (user is not null)
            _db.UserOrders.Remove(user);

        return true;
    }

    public async Task UpdateUserOrder(UserOrder userOrder)
    {
        var user = await Find(userOrder.UserId);
        user?.Update(userOrder.OrdersInCurrentMonth, userOrder.EndDate);
    }
}