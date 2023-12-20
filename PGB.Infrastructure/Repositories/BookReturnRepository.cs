using PGB.Application.IRepositories;
using PGB.Domain.Entities;
using PGB.Infrastructure.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace PGB.Infrastructure.Repositories;

public class BookReturnRepository : IBookReturnRepository
{
    private readonly IDBC _db;
    public BookReturnRepository(IDBC db) => _db = db;




    public async Task<bool> PostAsync(BookReturn bookReturn)
    {
        await _db.BookReturns.AddAsync(bookReturn);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<IEnumerable<Book>> Return(BookReturn bookReturn)
    {
        return Task.FromResult(bookReturn.Books);
    }
}
