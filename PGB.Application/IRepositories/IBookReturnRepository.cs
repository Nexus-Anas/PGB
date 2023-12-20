using PGB.Domain.Entities;

namespace PGB.Application.IRepositories;

public interface IBookReturnRepository
{
    Task<bool> PostAsync(BookReturn bookReturn);
    Task<IEnumerable<Book>> Return(BookReturn bookReturn);
}
