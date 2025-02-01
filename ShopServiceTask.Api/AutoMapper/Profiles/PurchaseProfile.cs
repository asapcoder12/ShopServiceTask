using AutoMapper;
using ShopServiceTask.Api.Models.Purchase;
using ShopServiceTask.Business.DTO;

namespace ShopServiceTask.Api.AutoMapper.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<PurchaseItemModel, PurchaseItemDTO>();
            CreateMap<CreatePurchaseModel, PurchaseDTO>();
        }
    }
}
