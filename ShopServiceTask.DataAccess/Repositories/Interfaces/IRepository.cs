using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IQueryable<T>> includeProperties = null, bool isTracking = true);
        void Delete(T entity);
        void Update(T entity);
    }
}
