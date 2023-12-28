using MediatR;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Application.Interfaces;

namespace PGB.Application.Models.BookOrder.Command.RegisterBookOrder;

public class RegisterBookOrderCmdHandler : IRequestHandler<RegisterBookOrderCmd, bool>
{
    private readonly IRegisterBookOrderService _service;
    public RegisterBookOrderCmdHandler(IRegisterBookOrderService service) => _service = service;




    public async Task<bool> Handle(RegisterBookOrderCmd request, CancellationToken cancellationToken)
    {
        BookOrderPostDTO bookOrderPostDTO = new()
        {
            UserId = request.UserId,
            Books = request.Books
        };

        var (success, msg) = await _service.RegisterBookOrder(bookOrderPostDTO);
        return success;
    }
}
