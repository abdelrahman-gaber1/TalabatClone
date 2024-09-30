using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Models;
using Talabat.Core.Repositories.Contract;

namespace Talabat.APIS.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _prodictRepo;

        public ProductController(IGenericRepository<Product> prodictRepo)
        {
            _prodictRepo = prodictRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products =await _prodictRepo.GetAllAsync();
            return Ok(products);
        }
    }
}
