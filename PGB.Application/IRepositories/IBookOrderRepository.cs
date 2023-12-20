using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBookOrderRepository
{
    Task<bool> PostAsync(BookOrder bookOrder);
    Task<IEnumerable<Book>> Order(BookOrder bookOrder);
}
