using AutoMapper;
using SignalR.Dto.AboutDto;
using SignalR.Dto.CategoryDto;
using SignalR.Entity.Entities;

namespace SignalRApi.GenerelMapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
        }
    }
}
