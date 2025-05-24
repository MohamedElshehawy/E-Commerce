using E_Commerce.Core.Entities;
using E_Commerce.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Specifications
{
    public class SpecificationEvaluator<TEntity , TKey>  where TEntity: BaseEntity<TKey>
    {
        public static IQueryable<TEntity> BuildQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> specification)
        {
            var query = inputQuery;
            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);

            //foreach (var item in specification.IncludExpressions)
            //{
            //    query = query.Include(item);
            //}
            if (specification.OrderBy is not null)
                query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDesc is not null)
                query = query.OrderByDescending(specification.OrderByDesc);

            if (specification.IsPaginated)
                query =query.Skip(specification.Skip).Take(specification.Take);

            if (specification.IncludExpressions.Any()) 
                query = specification.IncludExpressions
                    .Aggregate(query, (currentquery, expression) => currentquery.Include(expression));



            return query;
        }
    }
}
