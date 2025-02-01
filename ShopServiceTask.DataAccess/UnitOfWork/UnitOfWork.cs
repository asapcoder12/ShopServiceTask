using ShopServiceTask.DataAccess.EF;
using ShopServiceTask.DataAccess.Repositories.Implementations;
using ShopServiceTask.DataAccess.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private CustomerRepository _customerRepository;
        private GoodRepository _goodRepository;
        private GoodCategoryRepository _goodCategoryRepository;
        private PurchaseRepository _purchaseRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public CustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);
        public GoodRepository GoodRepository => _goodRepository ??= new GoodRepository(_context);
        public GoodCategoryRepository GoodCategoryRepository => _goodCategoryRepository ??= new GoodCategoryRepository(_context);
        public PurchaseRepository PurchaseRepository => _purchaseRepository ??= new PurchaseRepository(_context);
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
