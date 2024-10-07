using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Core.Specification
{
    public interface ISpecification<T> where T : BaseModel
    {
        public Expression<Func<T,bool>> criteria { get; set; }
        public List<Expression<Func<T,object>>> includes { get; set; }
    }
}
