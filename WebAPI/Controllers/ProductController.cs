using Business.Abstract;
using Business.Contants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAllProduct()
        {
            var products = _productManager.GetProduct();

            if(products.Count == 0)
            {
                return Ok(new { status = 200, message = "Hec bir mehsul tapilmadi" });
            }
            return Ok(new { status = 200, message = products });
        }

        [HttpPost("add")]
        public IActionResult AddProduct(AddProductDTO product)
        {

            try
            {
                _productManager.AddProduct(product);

            }
            catch (Exception e)
            {
                return Ok(new {status = 400, message = e});
            }
            return Ok(new {status = 200, message = "Mehsul elave olundu"});
        }

        [HttpGet("productlist")]
        public IActionResult ProductList()
        {
            var productList = _productManager.GetAllProductList();
            return Ok(new { status = 200, message = productList });
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id){
            var product = _productManager.GetProductById(id);
            return Ok(new {status = 200, message = product});
        }

        [HttpPut("update")]
        public IActionResult UpdateCategory(UpdateProductDTO product)
        {
            try
            {
                _productManager.Update(product);
            }
            catch (Exception e)
            {

                return Ok(new { status = 400, message = e });

            }
            return Ok(new { status = 200, message = "Mehsul yenilendi" });
        }

    }
}
