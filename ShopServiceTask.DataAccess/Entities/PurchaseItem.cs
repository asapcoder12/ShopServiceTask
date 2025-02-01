using System.ComponentModel.DataAnnotations.Schema;

namespace ShopServiceTask.DataAccess.Entities
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }


        [ForeignKey("Good")]
        public int GoodId { get; set; }
        public virtual Good Good { get; set; }

        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}