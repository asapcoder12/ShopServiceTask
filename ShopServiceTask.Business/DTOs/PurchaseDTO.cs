using ShopServiceTask.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.Business.DTO
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        public List<PurchaseItemDTO> Items { get; set; }
    }
}
