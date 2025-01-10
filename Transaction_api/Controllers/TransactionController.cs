using Microsoft.AspNetCore.Mvc;
using Transaction_api.Context;
using Transaction_api.NewFolder;
using Transaction_api.Repositories;
namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {

        private readonly CategoryContext _categoryContext;
        private readonly ProductContext _productcontext;
        private readonly StoreContext _storecontext;
        private readonly TransactionRepo _repo;

        public TransactionController(TransactionRepo repo)
        {
            _repo = repo;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public void addtransaction()
        {
            //_repo.add()
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Segment?> getsegment(int id)
        {
            return _repo.getid(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void updatesegment(int id)
        {
            //_repo.updatetransaction()
        }
    }
}
