using PGB.Application.DTOs.BookDTO;

namespace PGB.Application.DTOs.BookOrderDTO;

public class BookOrderPutDTO
{
    public int UserId { get; set; }
    public IEnumerable<BookGetDTO> Books { get; set; }
}