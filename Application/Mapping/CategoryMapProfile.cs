using Application.DTOs.CategoryDto.Request;
using Application.DTOs.CategoryDto.Responce;

using AutoMapper;
using Domain.Models;

namespace Application.Mapping
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile() 
        {
            CreateMap<Category, CategoryGetAllResponce>()
                .ForMember(dest => dest.СategoryName, opt =>
                opt.MapFrom(src => src.CategoryName));

            CreateMap<Category, CategoryGetByIdResponce>()
                .ForMember(dest => dest.СategoryName, opt =>
                opt.MapFrom(src => src.CategoryName));

            CreateMap<Category, CategoryCreateResponce>()
                .ForMember(dest => dest.СategoryName, opt =>
                opt.MapFrom(src => src.CategoryName));

            CreateMap<Category, CategotyUpdateResponce>()
                .ForMember(dest => dest.СategoryName, opt =>
                opt.MapFrom(src => src.CategoryName));

            CreateMap<CategoryCreateRequest,Category>()
                .ConstructUsing(dto => new Category
                (
                    Guid.NewGuid(),
                    dto.СategoryName
                ));

            CreateMap<CategoryUpdateRequest,Category>()
                .ConstructUsing(dto => new Category
                (
                    dto.Id,
                    dto.СategoryName
                ));
        }
    }
}
