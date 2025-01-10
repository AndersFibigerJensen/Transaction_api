using Microsoft.AspNetCore.Mvc;
using Transaction_api.Models;
using Transaction_api.Repositories;

namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductCategoryController:ControllerBase
    {
        private CategoryRepo _categoryRepo;

        public ProductCategoryController(CategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Product_category>> getcategories()
        {
           List<Product_category> category= _categoryRepo.getall().Result;
            return category;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product_category> category(int id)
        {
            Product_category cat= _categoryRepo.getstore(id).Result;
            return cat;
        }


    }
}
