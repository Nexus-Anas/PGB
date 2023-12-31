using PGB.Application.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGB.Application.BookOrders.Commands;

public record BookOrderResult(string Msg, IEnumerable<BookGetDTO> Books);