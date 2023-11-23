using Api.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace Api.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    { 
        CreateMap<Customer,CustomerDto>().ReverseMap();
        CreateMap<Employee,EmployeeDto>().ReverseMap();
        CreateMap<Office,OfficeDto>().ReverseMap();
        CreateMap<Order,OrderDto>().ReverseMap();
        CreateMap<OrderDetail,OrderDetailDto>().ReverseMap();
        CreateMap<Product,ProductDto>().ReverseMap();
        CreateMap<ProductType,ProductTypeDto>().ReverseMap();
        CreateMap<Payment,PaymentDto>().ReverseMap();

    }
}
