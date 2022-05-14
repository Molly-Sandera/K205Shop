using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }


        [HttpGet("getall")]
        public List<Category> GetAll()
        {
            return _categoryManager.GetAllCategories() ;
        }

        [HttpPost("add")]
        public object AddCategory(Category category)
        {
            _categoryManager.Add(category);
            return Ok("Category added");
        }

        [HttpPut("update")]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryManager.Update(category);
            return Ok(new {status = 200, message = category});
        }

        [HttpDelete("remove")]
        public IActionResult DeleteCategory(Category category)
        {
            _categoryManager.Remove(category);
            return Ok("Melumat ugurla silindi");
        }
    }
}
