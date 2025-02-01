using System.ComponentModel.DataAnnotations;

namespace ShopServiceTask.Api.Models.Good
{
    public class CreateGoodCategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}
