using PGB.Application.DTOs.BookOrderDTO;

namespace PGB.Application.Interfaces;

public interface IRegisterBookOrderService
{
    Task<(bool, string)> RegisterBookOrder(BookOrderPostDTO bookOrderPostDTO);
}