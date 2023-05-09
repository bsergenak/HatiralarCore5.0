using Hatiralar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Core.DataAccess.EntityFramework
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity, new()
    {
        DbContext _db;
        DbSet<T> set;
        public RepositoryBase(DbContext db)
        {
            _db = db;
            set = _db.Set<T>();
        }
        public async Task Add(T entity)
        {
            set.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            set.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await set.ToListAsync() : await set.Where(expression).ToListAsync();
        }

        public async Task<T> GetT(Expression<Func<T, bool>> expression)
        {
            return await set.FirstOrDefaultAsync(expression);
        }

        public async Task Update(T entity)
        {
            set.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
