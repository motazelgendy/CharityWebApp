using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Charity.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        IEnumerable<T> GetAll(string? IncludeProperties=null, Expression<Func<T, bool>>? filter = null);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter= null, string? IncludeProperties = null);

    }
}
