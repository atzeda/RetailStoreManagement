using AutoMapper;
using RetailStoreManagement.DTOs;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();

            CreateMap<PurchaseCreateDto, Purchase>();
            CreateMap<PurchaseItemDto, PurchaseItem>();
        }
    }
}