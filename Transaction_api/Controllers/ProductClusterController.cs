using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        public ActionResult<List<ProductCluster>> GetAll([FromQuery] int category_id, [FromQuery] int cluster_id, [FromQuery] int hour)
        {
            return _repo.getall().Result;
        }
    }
}
