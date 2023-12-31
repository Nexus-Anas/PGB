using MediatR;
using PGB.Application.DTOs.BookDTO;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Application.Interfaces;

namespace PGB.Application.BookOrders.Commands;

public class RegisterBookOrderCommandHandler : IRequestHandler<RegisterBookOrderCommand, BookOrderResult>
{
    private readonly IRegisterBookOrderService _service;
    public RegisterBookOrderCommandHandler(IRegisterBookOrderService service) => _service = service;




    public async Task<BookOrderResult> Handle(RegisterBookOrderCommand request, CancellationToken cancellationToken)
    {
        BookOrderPostDTO bookOrderPostDTO = new()
        {
            UserId = request.userId,
            Books = request.books
        };

        var (books, msg) = await _service.RegisterBookOrder(bookOrderPostDTO);
        return new BookOrderResult(msg, books);
    }
}