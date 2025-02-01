using System.ComponentModel.DataAnnotations.Schema;

namespace ShopServiceTask.DataAccess.Entities
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual GoodCategory Category { get; set; }

        public string Article { get; set; }
        public decimal Price { get; set; }

        public virtual List<PurchaseItem> PurchaseItems { get; set; }
    }
}