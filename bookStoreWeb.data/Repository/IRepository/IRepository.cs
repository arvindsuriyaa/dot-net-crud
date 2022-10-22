using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProp = null);

        void Add(T entity);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProp = null);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        IEnumerable<T> GetRepo();





    }
}
