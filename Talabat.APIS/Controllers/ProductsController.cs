using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Models;
using Talabat.Core.Repositories.Contract;
  
namespace Talabat.APIS.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _prodictRepo;

        public ProductsController(IGenericRepository<Product> prodictRepo)
        {
            _prodictRepo = prodictRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products =await _prodictRepo.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _prodictRepo.GetAsync(id);
            if(product == null)
            {
                return NotFound(new {massage = "Not Found" , statusCode = 404});
            }
            return Ok(product);
        }
    }
}
