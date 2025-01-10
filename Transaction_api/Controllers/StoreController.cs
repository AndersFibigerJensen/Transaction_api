using Microsoft.AspNetCore.Mvc;
using Transaction_api.Models;
using Transaction_api.Repositories;

namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class StoreController:ControllerBase
    {
        private StoreRepo repo;

        public StoreController(StoreRepo Repo)
        {
            repo = Repo;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<List<Store>> GetStores()
        {
            List<Store> store=repo.getstores().Result;
            return store;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<Store> GetStore(int id)
        {
            Store? store = repo.getstore(id).Result;
            return store;
        }
    }
}
