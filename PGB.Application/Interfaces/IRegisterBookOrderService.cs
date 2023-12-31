using PGB.Application.DTOs.BookDTO;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Domain.Entities;

namespace PGB.Application.Interfaces;

public interface IRegisterBookOrderService
{
    Task<(IEnumerable<BookGetDTO>, string)> RegisterBookOrder(BookOrderPostDTO bookOrderPostDTO);
}