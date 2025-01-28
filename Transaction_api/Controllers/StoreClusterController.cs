using Microsoft.AspNetCore.Mvc;
using Transaction_api.Models;
using Transaction_api.Repositories;

namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class StoreClusterController:ControllerBase
    {
        private StoreClusterRepo _storeClusterRepo;

        public StoreClusterController(StoreClusterRepo Repo)
        {
            _storeClusterRepo = Repo;
        }


        [HttpGet]
        public ActionResult<int> getall([FromQuery] int category, [FromQuery] int store_id, [FromQuery] int cluster)
        {
            return _storeClusterRepo.getall(store_id,cluster,category).Result;
        }

        [HttpGet("store")]
        public ActionResult<List<int>> get()
        {
            return _storeClusterRepo.getstores().Result;
        }

        [HttpGet("Clusters")]
        public ActionResult<List<int>> getClusters()
        {
            return _storeClusterRepo.getClusters().Result;
        }

        [HttpGet("Categories")]
        public ActionResult<List<int>> getCategories()
        {
            return _storeClusterRepo.getCategories().Result;
        }
    }
}
