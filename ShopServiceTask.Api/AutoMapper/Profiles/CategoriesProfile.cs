using AutoMapper;
using ShopServiceTask.Api.Models.Customer;
using ShopServiceTask.Business.DTO;

namespace ShopServiceTask.Api.AutoMapper.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<PopularGoodCategoryDTO, PopularGoodCategoryModel>();
        }
    }
}
