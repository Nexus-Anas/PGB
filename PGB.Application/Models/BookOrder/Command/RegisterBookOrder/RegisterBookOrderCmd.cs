using MediatR;
using PGB.Application.DTOs.BookDTO;

namespace PGB.Application.Models.BookOrder.Command.RegisterBookOrder;

public record RegisterBookOrderCmd : IRequest<bool>
{
    public int UserId { get; set; }
    public IEnumerable<BookPostDTO> Books { get; set; }
}
