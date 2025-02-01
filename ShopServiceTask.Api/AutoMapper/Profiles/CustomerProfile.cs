using AutoMapper;
using ShopServiceTask.Api.Models.Customer;
using ShopServiceTask.Business.DTO;

namespace ShopServiceTask.Api.AutoMapper.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerModel, CustomerDTO>();

            CreateMap<CustomerDTO, BirthdayPersonModel>()
                .ForMember(birthdayPersonModel => birthdayPersonModel.FullName,
                expression => expression.MapFrom(customerDTO => $"{customerDTO.LastName} {customerDTO.FirstName} {customerDTO.SecondName}"));

            CreateMap<CustomerDTO, RecentCustomerModel>()
                .ForMember(recentCustomerModel => recentCustomerModel.LastPurchaseDate, 
                expression => expression.MapFrom(customerDTO => customerDTO.Purchases.Max(p => p.PurchaseDate)))
                .ForMember(birthdayPersonModel => birthdayPersonModel.FullName,
                expression => expression.MapFrom(customerDTO => $"{customerDTO.LastName} {customerDTO.FirstName} {customerDTO.SecondName}"));
        }
    }
}
