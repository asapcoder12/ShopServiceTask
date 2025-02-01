using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.Business.DTO
{
    public class PopularGoodCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoodsCount { get; set; }
    }
}
