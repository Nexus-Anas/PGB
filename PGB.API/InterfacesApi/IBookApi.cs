using PGB.API.ModelsApi;
using Refit;

namespace PGB.API.InterfacesApi;

public interface IBookApi
{
    [Get("/Book/{id}")]
    Task<Book> GetBookAsync(int id);
}
