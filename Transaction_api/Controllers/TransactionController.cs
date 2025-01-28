using Microsoft.AspNetCore.Mvc;
using Transaction_api.Context;
using Transaction_api.Models;
using Transaction_api.NewFolder;
using Transaction_api.Repositories;
namespace Transaction_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionRepo _repo;
        private readonly ProductRepo productrepo;

        public TransactionController(TransactionRepo repo,ProductRepo pro)
        {
            _repo = repo;
            productrepo = pro;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public void addtransaction([FromQuery] int storeid, [FromQuery] int product)
        {
            Product pro =productrepo.get(product).Result;
            DateTime time = DateTime.Now;
            int month=time.Month;
            int weekday = (int)time.DayOfWeek;
            int hour = time.Hour;
            Segment segment = new Segment(1, hour, weekday, month, 1, storeid, pro.Product_id,pro.Product_category);
            _repo.add(segment);
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
