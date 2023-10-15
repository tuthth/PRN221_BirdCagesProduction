using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _entities;

        public Repository(BirdCageManagementsContext context)
        {
            _entities = context.Set<T>();
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
        public IQueryable<T> ThenInclude(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRangeAsync(entities);
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public IQueryable<T> SkipAndTake(int skip, int take)
        {
            return _entities.Skip(skip).Take(take);
        }

        public IQueryable<T> Distinct(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate).Distinct();
        }

        public int Count()
        {
            return _entities.Count();
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _entities.UpdateRange(entities);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _entities.FirstOrDefault(predicate) ?? null!;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.FirstOrDefaultAsync(predicate) ?? null!;
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate).ToList().Count > 0;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _entities.Any(predicate);
        }
    }
}

