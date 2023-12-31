using MediatR;
using PGB.Application.DTOs.BookDTO;

namespace PGB.Application.BookOrders.Commands;

public record ReturnBookOrderCommand(int userId, IEnumerable<BookGetDTO> books) : IRequest<BookOrderResult>;