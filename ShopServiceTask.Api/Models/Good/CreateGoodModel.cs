using ShopServiceTask.Business.DTO;
using System.ComponentModel.DataAnnotations;

namespace ShopServiceTask.Api.Models.Good
{
    public class CreateGoodModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Article { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
