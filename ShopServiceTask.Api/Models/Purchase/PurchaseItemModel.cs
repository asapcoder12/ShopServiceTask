using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopServiceTask.Api.Models.Purchase
{
    public class PurchaseItemModel
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int GoodId { get; set; }
    }
}