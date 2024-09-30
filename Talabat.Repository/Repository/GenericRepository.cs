using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository.Data;

namespace Talabat.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly StoreContext _dbcontext;

        public GenericRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }
    }
}
