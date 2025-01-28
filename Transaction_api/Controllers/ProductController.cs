using Microsoft.AspNetCore.Mvc;
using Transaction_api.Models;
using Transaction_api.Repositories;

namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductController
    {
        private ProductRepo Repo;

        public ProductController(ProductRepo repo)
        {
            Repo = repo;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<List<Product>> GetStores()
        {
            List<Product> products = Repo.getall().Result;
            return products;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<Product> GetStore(int id)
        {
            Product product = Repo.get(id).Result;
            return product;
        }
    }
}
