using Application.DTOs.SupplierDto.Request;
using Application.DTOs.SupplierDto.Responce;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping
{
    public class SupplierMapProfile : Profile
    {
        public SupplierMapProfile() 
        {
            CreateMap<Supplier, SupplierGetAllResponce>();
            CreateMap<Supplier, SupplierGetByIdResponce>();
            CreateMap<Supplier, SupplierCreateResponce>();
            CreateMap<Supplier, SupplierUpdateResponce>();

            CreateMap<SupplierCreateRequest, Supplier>()
                .ConstructUsing(dto => new Supplier
                (
                    Guid.NewGuid(),
                    dto.CompanyName,
                    dto.ContactInfo
                ));

            CreateMap<SupplierUpdateRequest, Supplier>()
                .ConstructUsing(dto => new Supplier
                (
                    dto.Id,
                    dto.CompanyName,
                    dto.ContactInfo
                ));
        }
    }
}
