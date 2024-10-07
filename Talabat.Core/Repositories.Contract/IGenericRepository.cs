using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Core.Specification;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetWithSpecAsync(ISpecification<T> specification);
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> specification);

    }
}
