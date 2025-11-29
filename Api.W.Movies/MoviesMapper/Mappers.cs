using Api.W.Movies.DAL.Models;
using Api.W.Movies.DAL.Models.Dtos;
using AutoMapper;

namespace Api.W.Movies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }
    }
}
