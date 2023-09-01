using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.API.Data;
using TestProject.API.Models;

namespace TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly TestProjectDBContext _dbContext;

        public ProductController(TestProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var productList = await _dbContext.Products.ToListAsync();

            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == id);
            if (product == null) { return BadRequest("Ürün ID Bulunamadı"); }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            var productList = await _dbContext.Products.ToListAsync();

            return Ok(productList);
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {

            var updatedProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == product.ProductID);
            if (updatedProduct == null) { return BadRequest("Ürün ID Bulunamadı"); }
            updatedProduct.ProductName = product.ProductName;
            updatedProduct.ProductPrice = product.ProductPrice;

            await _dbContext.SaveChangesAsync();

            var productList = await _dbContext.Products.ToListAsync();

            return Ok(productList);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {

            var deletedProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == id);
            if (deletedProduct == null) { return NotFound("Silinecek Ürün Bulunamadı"); }

            _dbContext.Products.Remove(deletedProduct);
            await _dbContext.SaveChangesAsync();

            var productList = await _dbContext.Products.ToListAsync();

            return Ok(productList);
        }
    }
}