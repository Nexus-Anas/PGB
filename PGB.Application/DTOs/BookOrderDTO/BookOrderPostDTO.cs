using PGB.Application.DTOs.BookDTO;
using PGB.Domain.Entities;

namespace PGB.Application.DTOs.BookOrderDTO;

public class BookOrderPostDTO
{
    public int UserId { get; set; }
    public IEnumerable<BookGetDTO> Books { get; set; }
}