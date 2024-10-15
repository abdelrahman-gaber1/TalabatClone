using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.DTOs;
using Talabat.Core.Models;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specification;
using Talabat.Core.Specification.ProductSpecification;

namespace Talabat.APIS.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _prodictRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo , IMapper mapper)
        {
            _prodictRepo = productRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new ProductWithBrandCategorySpecification();
            var products =await _prodictRepo.GetAllWithSpecAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductWithBrandCategorySpecification(id);
            var product = await _prodictRepo.GetWithSpecAsync(spec);
            if(product == null)
            {
                return NotFound(new {massage = "Not Found" , statusCode = 404});
            }
            return Ok(_mapper.Map<Product,ProductDto>(product));
        }
    }
}
