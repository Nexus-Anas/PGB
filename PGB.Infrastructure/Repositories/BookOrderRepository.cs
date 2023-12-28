using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class BookOrderRepository : IBookOrderRepository
{
    private readonly IDBC _db;
    public BookOrderRepository(IDBC db) => _db = db;




    public async Task<BookOrder?> FindLastOrder(int user_id)
    {
        var order = await _db.BookOrders.LastOrDefaultAsync(x => x.UserId == user_id);
        return order;
    }

    public async Task<bool> Add(BookOrder bookOrder)
    {
        await _db.BookOrders.AddAsync(bookOrder);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<DateTime?> Update(BookOrder bookOrder)
    {
        var order = await FindLastOrder(bookOrder.UserId);
        if (order is not null)
        {
            order.ReturnDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return order.ReturnDate;
        }
        return default;
    }

    public async Task<IEnumerable<Book>> GetOrder(BookOrder bookOrder)
    {
        return await Task.FromResult(bookOrder.Books);
    }
}
