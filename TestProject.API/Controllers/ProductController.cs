using Microsoft.AspNetCore.Mvc;
using TestProject.API.Models;

namespace TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {   new Product { ProductID = 1, ProductName = "Marker Kalem",  ProductPrice = "300" },
            new Product { ProductID = 2, ProductName = "Dolma Kalem",   ProductPrice ="2000"},
            new Product { ProductID = 3, ProductName = null, ProductPrice =  null},
        };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = _products.Find(x => x.ProductID == id);
            if (product == null) { return BadRequest("Ürün ID Bulunamadı"); }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _products.Add(product);
            return Ok(_products);

            //Veya aşağıdaki gibi id eşit olanı getirebilir.
            //return Ok(_products.Where(x=>x.ProductID == product.ProductID));
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var updatedProduct = _products.Find(x => x.ProductID == product.ProductID);
            if (updatedProduct == null) { return BadRequest("Ürün ID Bulunamadı"); }
            updatedProduct.ProductName = product.ProductName;
            updatedProduct.ProductPrice = product.ProductPrice;

            return Ok(_products);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct (int id)
        {
            var deletedProduct = _products.Find(x=>x.ProductID == id);
            if (deletedProduct == null) { return NotFound("Silinecek Ürün Bulunamadı"); }

            _products.Remove(deletedProduct);
            return Ok(_products);
        }
    }
}