using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repo
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
        IQueryable<T> ThenInclude(params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetAll();

        IQueryable<T> GetMany(Expression<Func<T, bool>> predicate);

        IQueryable<T> SkipAndTake(int skip, int take);

        int Count();

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        bool Contains(Expression<Func<T, bool>> predicate);

        bool Any(Expression<Func<T, bool>> predicate);
    }
}
