using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.ISpecification
{
    public abstract class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public IList<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }

        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public void AddInclude(Expression<Func<T, object>> include) => Includes.Add(include);
        public void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;
        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending) => OrderByDescending = orderByDescending;

        public void ApplyPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
