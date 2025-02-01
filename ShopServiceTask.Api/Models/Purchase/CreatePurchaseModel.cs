using ShopServiceTask.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopServiceTask.Api.Models.Purchase
{
    public class CreatePurchaseModel
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public List<PurchaseItemModel> Items { get; set; }
    }
}
