using ShopServiceTask.DataAccess.EF;
using ShopServiceTask.DataAccess.Entities;
using ShopServiceTask.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.DataAccess.Repositories.Implementations
{
    public class GoodCategoryRepository : Repository<GoodCategory>
    {
        public GoodCategoryRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
