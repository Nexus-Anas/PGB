using AutoMapper;
using PGB.Application.DTOs.BookDTO;
using PGB.Application.DTOs.BookOrderDTO;
using PGB.Domain.Entities;

namespace PGB.Application.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //Book mapping
        CreateMap<BookGetDTO, Book>().ReverseMap();

        //BookOrder mapping
        CreateMap<BookOrderPostDTO, BookOrder>();
        CreateMap<BookOrderPutDTO, BookOrder>();
    }
}
