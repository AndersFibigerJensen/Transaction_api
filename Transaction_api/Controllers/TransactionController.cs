using Microsoft.AspNetCore.Mvc;
using Transactionsclass;

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
        public ActionResult<Transaction> gettransaction(int id)
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
        public ActionResult<Transaction?> update(int id, Transaction action)
        {
            gettransaction(id);
            return _repo.updatetransaction(id, action);
        }
    }
}
