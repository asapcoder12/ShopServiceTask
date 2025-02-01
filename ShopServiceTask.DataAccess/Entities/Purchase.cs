using System.ComponentModel.DataAnnotations.Schema;

namespace ShopServiceTask.DataAccess.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual List<PurchaseItem> Items { get; set; }
    }
}