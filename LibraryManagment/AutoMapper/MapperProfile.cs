using AutoMapper;
using LibraryManagment.Data.Entities;
using LibraryManagment.Model;

namespace LibraryManagment.AutoMapper
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Book, BookListModel>()
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.PublisherName));
        }
    }
}
