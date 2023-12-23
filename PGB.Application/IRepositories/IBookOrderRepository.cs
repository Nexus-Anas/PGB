using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBookOrderRepository
{
    Task<bool> PostAsync(BookOrder bookOrder);
    Task<BookOrder> FindLastOrder(int user_id);
    Task<DateTime?> PutAsync(BookOrder bookReturn);
    Task<IEnumerable<Book>> Order(BookOrder bookOrder);
}
