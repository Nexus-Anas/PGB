using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBookOrderRepository
{
    Task<BookOrder?> FindLastBookOrder(int user_id);
    Task<bool> AddBookOrder(BookOrder bookOrder);
    Task<IEnumerable<Book>> GetBooks(BookOrder bookOrder);
}
