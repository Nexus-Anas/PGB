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
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveUserOrder(int user_id)
    {
        var user = await Find(user_id);

        if (user is not null)
        {
            _db.UserOrders.Remove(user);
            await _db.SaveChangesAsync();
        }
        return true;
    }

    public async Task<bool> BlockUserOrder(int user_id)
    {
        var userOrder = await Find(user_id);
        if (userOrder is not null)
        {
            userOrder.EndDate = DateTime.Now.AddMonths(1);
            await _db.SaveChangesAsync();
        }
        return true;
    }

    public async Task<int> IncrementOrderInCurrentMonth(int user_id)
    {
        int value = 0;
        var userOrder = await Find(user_id);
        if (userOrder is not null)
        {
            userOrder.OrdersInCurrentMonth++;
            value = userOrder.OrdersInCurrentMonth;
            await _db.SaveChangesAsync();
        }
        return value;
    }
}