using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

    }
}
