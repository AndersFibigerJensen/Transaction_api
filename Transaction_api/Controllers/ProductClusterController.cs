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
        public ActionResult<int> GetAll([FromQuery] int category_id, [FromQuery] int cluster_id, [FromQuery] int hour)
        {
            return _repo.getall(category_id,cluster_id,hour).Result;
        }

        //[HttpGet("store")]
        //public ActionResult<List<int>> get()
        //{
        //    return _repo.getstores().Result;
        //}

        //[HttpGet("Clusters")]
        //public ActionResult<List<int>> getClusters()
        //{
        //    return _storeClusterRepo.getClusters().Result;
        //}

        //[HttpGet("Categories")]
        //public ActionResult<List<int>> getCategories()
        //{
        //    return _storeClusterRepo.getCategories().Result;
        //}
    }
}
