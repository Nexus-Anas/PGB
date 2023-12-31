using MediatR;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Application.Interfaces;

namespace PGB.Application.BookOrders.Commands;

public class ReturnBookOrderCommandHandler : IRequestHandler<ReturnBookOrderCommand, BookOrderResult>
{
    private readonly IReturnBookOrderService _service;
    public ReturnBookOrderCommandHandler(IReturnBookOrderService service) => _service = service;




    public async Task<BookOrderResult> Handle(ReturnBookOrderCommand request, CancellationToken cancellationToken)
    {
        BookOrderPutDTO bookOrderPutDTO = new()
        {
            UserId = request.userId,
            Books = request.books
        };

        var (books, msg) = await _service.ReturnBookOrder(bookOrderPutDTO);
        return new BookOrderResult(msg, books);
    }
}
