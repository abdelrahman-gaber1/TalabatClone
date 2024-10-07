using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Core.Specification;

namespace Talabat.Repository
{
    internal static class SpecificationEvaluatur<T> where T : BaseModel
    {
        public static IQueryable<T> GetQuery(IQueryable<T> innerQuery , ISpecification<T> spec)
        {
            var query = innerQuery;
            if(spec.criteria is not null)
            {
                query = query.Where(spec.criteria);
            }
            query = spec.includes.Aggregate(query, (currentQuery, includesExpression) => currentQuery.Include(includesExpression));
            return query;
        }
    }
}
