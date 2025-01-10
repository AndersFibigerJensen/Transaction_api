using Microsoft.AspNetCore.Mvc;
using Transaction_api.Models;
using Transaction_api.Repositories;

namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductClusterController:ControllerBase
    {
        private ProductClusterRepo _repo;

        public ProductClusterController(ProductClusterRepo repo)
        {
            _repo = repo;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<List<ProductCluster>> GetAll()
        {
            return _repo.getall().Result;
        }
    }
}
