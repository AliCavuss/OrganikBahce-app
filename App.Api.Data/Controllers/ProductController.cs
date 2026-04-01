using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataRepository<ProductEntity> _productRepository;

        public ProductController(IDataRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }
    }
}
