using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBookOrderRepository
{
    Task<BookOrder?> FindLastOrder(int user_id);
    Task<bool> Add(BookOrder bookOrder);
    Task<DateTime?> Update(BookOrder bookReturn);
    Task<IEnumerable<Book>> GetOrder(BookOrder bookOrder);
}
