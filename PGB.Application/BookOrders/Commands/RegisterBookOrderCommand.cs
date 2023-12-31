using MediatR;
using PGB.Application.DTOs.BookDTO;

namespace PGB.Application.BookOrders.Commands;

public record RegisterBookOrderCommand(int userId, IEnumerable<BookGetDTO> books) : IRequest<BookOrderResult>;