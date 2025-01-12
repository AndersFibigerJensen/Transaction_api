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
        private readonly TransactionRepo _repo;

        public TransactionController(TransactionRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public void addtransaction()
        {
            //_repo.add();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Segment?> getsegment(int id)
        {
            return _repo.getid(id).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void updatesegment(int id)
        {
            //_repo.updatetransaction()
        }
    }
}
