using AutoMapper;
using ShopServiceTask.Api.Models.Good;
using ShopServiceTask.Business.DTO;

namespace ShopServiceTask.Api.AutoMapper.Profiles
{
    public class GoodProfile : Profile
    {
        public GoodProfile()
        {
            CreateMap<CreateGoodModel, GoodDTO>();
            CreateMap<CreateGoodCategoryModel, GoodCategoryDTO>();
        }
    }
}
