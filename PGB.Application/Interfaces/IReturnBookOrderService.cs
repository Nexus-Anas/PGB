using PGB.Application.DTOs.BookOrderDTO;

namespace PGB.Application.Interfaces;

public interface IReturnBookOrderService
{
    Task<(bool, string)> ReturnBookOrder(BookOrderPutDTO bookOrderPutDTO);
}
