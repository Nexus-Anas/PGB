using MediatR;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Application.Interfaces;

namespace PGB.Application.Models.BookOrder.Command.RegisterBookOrder;

public class RegisterBookOrderCmdHandler : IRequestHandler<RegisterBookOrderCmd, bool>
{
    private readonly IBookOrderService _service;
    public RegisterBookOrderCmdHandler(IBookOrderService service) => _service = service;




    public async Task<bool> Handle(RegisterBookOrderCmd request, CancellationToken cancellationToken)
    {
        BookOrderPostDTO bookOrderPostDTO = new()
        {
            UserId = request.UserId,
            Books = request.Books
        };

        bool success = await _service.RegisterBookOrder(bookOrderPostDTO);
        return success;
    }
}
