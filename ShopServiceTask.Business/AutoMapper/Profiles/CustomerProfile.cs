using AutoMapper;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.DataAccess.Entities;

namespace ShopServiceTask.Business.AutoMapper.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
