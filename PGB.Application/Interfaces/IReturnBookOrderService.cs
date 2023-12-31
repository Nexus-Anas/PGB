using PGB.Application.DTOs.BookDTO;
using PGB.Application.DTOs.BookOrderDTO;

namespace PGB.Application.Interfaces;

public interface IReturnBookOrderService
{
    Task<(IEnumerable<BookGetDTO>, string)> ReturnBookOrder(BookOrderPutDTO bookOrderPutDTO);
}