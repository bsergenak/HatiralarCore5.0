using Hatiralar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Core.DataAccess
{
    public interface IRepository<T> where T:class,IEntity,new()
    {
        Task<T> GetT(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll(Expression<Func<T,bool>> expression = null);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
