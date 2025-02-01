using AutoMapper;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.DataAccess.Entities;

namespace ShopServiceTask.Api.AutoMapper.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<PurchaseItemDTO, PurchaseItem>();
            CreateMap<PurchaseDTO, Purchase>().ReverseMap();
        }
    }
}
