using Microsoft.AspNetCore.Mvc;
using Transaction_api.NewFolder;
using Transaction_api.Repositories;
namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {

        private TransactionRepo _repo;

        public TransactionController(TransactionRepo repo)
        {
            _repo = repo;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public void addtransaction()
        {

        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Transactions> gettransaction(int id)
        {
            try
            {
                return Ok(_repo.getid(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Transactions?> update(int id, Transactions action)
        {
            gettransaction(id);
            return _repo.updatetransaction(id, action);
        }
    }
}
