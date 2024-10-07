using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specification;
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
            if (typeof(T) == typeof(Product)) 
            {
                return (IEnumerable<T>) await _dbcontext.Set<Product>().Include(P=>P.Brand).Include(P=>P.Category).AsNoTracking().ToListAsync();
            }
            return await _dbcontext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            if(typeof(T) == typeof(Product))
            {
                return  await _dbcontext.Set<Product>().Where(P => P.Id == id).Include(P => P.Brand).Include(P => P.Category).FirstOrDefaultAsync() as T;
            }
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetWithSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }
        private  IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluatur<T>.GetQuery(_dbcontext.Set<T>() , specification);
        }
    }
}
