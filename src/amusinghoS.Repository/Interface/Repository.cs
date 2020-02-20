using amusinghoS.EntityData;
using amusinghoS.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace amusinghoS.Interface.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly amusinghoSDbContext _dbContext;
        private DbSet<T> _entity;

        public Repository(amusinghoSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> Entity => _entity ?? (_entity = _dbContext.Set<T>());
        public int Add(T entity)
        {
            Entity.Add(entity);
            return _dbContext.SaveChanges();
        }
        public int AddRange(List<T> list)
        {
            Entity.AddRange(list);
            return _dbContext.SaveChanges();
        }
        public int Remove(T entity)
        {
            Entity.Remove(entity);
            return _dbContext.SaveChanges();
        }
        public int RemoveRange(List<T> list)
        {
            Entity.RemoveRange(list);
            return _dbContext.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable().AsNoTracking();
        }
        public Page<T> SearchFor<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate, bool isAsc,
            Expression<Func<T, TKey>> keySelector)
        {
            if (pageIndex <= 0 || pageSize <= 0) throw new Exception("pageIndex或pageSize不能小于等于0");
            var page = new Page<T> { PageIndex = pageIndex, PageSize = pageSize };
            var skip = (pageIndex - 1) * pageSize;
            var able = Entity.AsQueryable().AsNoTracking();
            if (predicate == null)
            {
                var count = Entity.Count();
                var query = isAsc
                    ? able.OrderBy(keySelector).Skip(skip).Take(pageSize)
                    : able.OrderByDescending(keySelector).Skip(skip).Take(pageSize);
                page.TotalRows = count;
                page.LsList = query.ToList();
                page.TotalPages = page.TotalRows / pageSize;
                if (page.TotalRows % pageSize != 0) page.TotalPages++;
            }
            else
            {
                var queryable = able.Where(predicate);
                var count = queryable.Count();
                var query = isAsc
                    ? queryable.OrderBy(keySelector).Skip(skip).Take(pageSize)
                    : queryable.OrderByDescending(keySelector).Skip(skip).Take(pageSize);
                page.TotalRows = count;
                page.LsList = query.ToList();
                page.TotalPages = page.TotalRows / pageSize;
                if (page.TotalRows % pageSize != 0) page.TotalPages++;
            }
            return page;
        }
        public T GetModelById(object id)
        {
            return Entity.Find(id);
        }

        public T GetModel(Expression<Func<T, bool>> predicate)
        {
            return Entity.FirstOrDefault(predicate);
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? Entity.Where(predicate).Count() : Entity.Count();
        }
        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return Entity.Any(anyLambda);
        }
    }
}
