using AutoMapper;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.DataAccess.Entities;

namespace ShopServiceTask.Business.AutoMapper.Profiles
{
    public class GoodProfile : Profile
    {
        public GoodProfile()
        {
            CreateMap<GoodCategoryDTO, GoodCategory>();
            CreateMap<GoodDTO, Good>();
        }
    }
}
