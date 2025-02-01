using ShopServiceTask.DataAccess.EF;
using ShopServiceTask.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.DataAccess.Repositories.Implementations
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
