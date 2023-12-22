using PGB.Domain.Entities;

namespace PGB.Application.DTOs.BookOrderDTO;

public class BookOrderPutDTO
{
    public int UserId { get; set; }
    public IEnumerable<Book> Books { get; set; }
    public DateTime ReturnDate { get; set; }
}