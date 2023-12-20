using Microsoft.EntityFrameworkCore;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;

namespace PGB.Infrastructure.Repositories;

public class BookOrderRepository : IBookOrderRepository
{
    private readonly IDBC _db;
    public BookOrderRepository(IDBC db) => _db = db;




    public async Task<bool> PostAsync(BookOrder bookOrder)
    {
        await _db.BookOrders.AddAsync(bookOrder);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<IEnumerable<Book>> Order(BookOrder bookOrder)
    {
        return Task.FromResult(bookOrder.Books);
    }
}
