using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class UserOrderRepository : IUserOrderRepository
{
    private readonly IDBC _db;
    public UserOrderRepository(IDBC db) => _db = db;

    public async Task<bool> BlockOrder(int id)
    {
        var userOrder = await _db.UserOrders.FindAsync(id);
        if (userOrder is not null)
        {
            userOrder.EndDate = DateTime.Now.AddMonths(1);
            await _db.SaveChangesAsync();
        }
        return true;
    }

    public async Task<UserOrder?> GetAsync(int id)
    {
        var userOrder = await _db.UserOrders.FindAsync(id);
        return userOrder;
    }

    public async Task<int> IncrementOrderBlockAsync(int id)
    {
        int value = 0;
        var userOrder = await _db.UserOrders.FindAsync(id);
        if (userOrder is not null)
        {
            userOrder.OrdersInCurrentMonth++;
            value = userOrder.OrdersInCurrentMonth;
            await _db.SaveChangesAsync();
        }
        return value;
    }

    public async Task<bool> PostOrderBlockAsync(UserOrder userOrder)
    {
        await _db.UserOrders.AddAsync(userOrder);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveOrderBlockAsync(int id)
    {
        var user = await _db.UserOrders.FindAsync(id);

        if (user is not null)
        {
            _db.UserOrders.Remove(user);
            await _db.SaveChangesAsync();
        }
        return true;
    }
}
