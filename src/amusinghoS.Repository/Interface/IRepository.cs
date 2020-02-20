using amusinghoS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace amusinghoS.Interface.Repository
{
        public interface IRepository<T> where T : class
        {
            int Add(T entity);
            int AddRange(List<T> list);
            int Remove(T entity);
            int RemoveRange(List<T> list);
            IQueryable<T> GetAll();
            /// <returns></returns>
            Page<T> SearchFor<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate,
                bool isAsc, Expression<Func<T, TKey>> keySelector);
            T GetModelById(object id);
            T GetModel(Expression<Func<T, bool>> predicate);
            int Count(Expression<Func<T, bool>> predicate);
            bool Exist(Expression<Func<T, bool>> anyLambda);
    }
}
