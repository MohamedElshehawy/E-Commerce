using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Interfaces
{
    public interface ISpecification<T>
    {
        // Where Criteria
        public Expression<Func<T,bool>> Criteria { get;  }
        // Includes
        public List<Expression<Func<T, object>>> IncludExpressions { get; }
        public Expression<Func<T, object>> OrderBy { get; }
        public Expression<Func<T, object>> OrderByDesc { get; }
        public int Skip { get;}
        public int Take { get;}
        public bool IsPaginated { get;}
    }
}
