using ShopServiceTask.DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.DataAccess.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        public CustomerRepository CustomerRepository { get; }
        public GoodRepository GoodRepository { get; }
        public GoodCategoryRepository GoodCategoryRepository { get; }
        public PurchaseRepository PurchaseRepository { get; }
        Task Save();
    }
}
