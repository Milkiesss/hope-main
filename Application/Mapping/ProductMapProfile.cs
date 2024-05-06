using Application.DTOs.CategoryDto;
using Application.DTOs.ProductDto.Request;
using Application.DTOs.ProductDto.Responce;
using Application.DTOs.SupplierDto;
using AutoMapper;
using Domain.Models;


namespace Application.Mapping
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductCreateResponce>()
                .ForMember(dest => dest.categoryDto, opt => opt.MapFrom(src => new BaseCategoryDto//проверить работате лли без этого
                {
                    СategoryName = src.Category.CategoryName
                }))
                .ForMember(dest => dest.supplierDto, opt => opt.MapFrom(src => new BaseSupplierDto
                {
                    CompanyName = src.Supplier.CompanyName,
                    ContactInfo = src.Supplier.ContactInfo
                }));

            CreateMap<Product, ProductUpdateResponce>()
                .ForMember(dest => dest.categoryDto, opt => opt.MapFrom(src => new BaseCategoryDto
                {
                    СategoryName = src.Category.CategoryName
                }))
                .ForMember(dest => dest.supplierDto, opt => opt.MapFrom(src => new BaseSupplierDto
                {
                    CompanyName = src.Supplier.CompanyName,
                    ContactInfo = src.Supplier.ContactInfo
                }));

            CreateMap<Product, ProductGetAllResponce>()
                .ForMember(dest => dest.categoryDto, opt => opt.MapFrom(src => new BaseCategoryDto
                 {
                     СategoryName = src.Category.CategoryName
                 }))
                .ForMember(dest => dest.supplierDto, opt => opt.MapFrom(src => new BaseSupplierDto
                {
                    CompanyName = src.Supplier.CompanyName,
                    ContactInfo = src.Supplier.ContactInfo
                }));

            CreateMap<Product, ProductGetByIdResponce>()
                .ForMember(dest => dest.categoryDto, opt => opt.MapFrom(src => new BaseCategoryDto
                {
                    СategoryName = src.Category.CategoryName
                }))
                .ForMember(dest => dest.supplierDto, opt => opt.MapFrom(src => new BaseSupplierDto
                {
                    CompanyName = src.Supplier.CompanyName,
                    ContactInfo = src.Supplier.ContactInfo
                }));

            CreateMap<ProductCreateRequest, Product>()
                .ConstructUsing(dto => new Product
                (
                    Guid.NewGuid(),
                    dto.Name,
                    dto.UnitOfMeasure,
                    dto.Available,
                    dto.ExpiryDate,
                    dto.Price,
                    dto.CategoryId,
                    dto.SupplierId
                ));

            CreateMap<ProductUpdateRequest, Product>()
                .ConstructUsing(dto => new Product
                (
                    dto.Id,
                    dto.Name,
                    dto.UnitOfMeasure,
                    dto.Available,
                    dto.ExpiryDate,
                    dto.Price,
                    dto.CategoryId,
                    dto.SupplierId
                ));
        }
    }
}
