using Transaction_api.Context;
using Transaction_api.NewFolder;
namespace Transaction_api.Repositories
{
    public class TransactionRepo
    {
        private TransactionContext _db;
        private int id_counter = 149117;

        public TransactionRepo(TransactionContext dbcontext)
        {
            _db = dbcontext;
        }

        public void add(Transactions action)
        {
            id_counter++;
            action.Transaction_id = id_counter;
            action.Transaction_time = DateTime.Now;
            Segment segment = new Segment();
            segment.year = action.Transaction_time.Year;
            segment.month = action.Transaction_time.Month;
            segment.hour = action.Transaction_time.Hour;
            segment.weekday = ((int)action.Transaction_time.DayOfWeek);
            _db.Transactions.Add(action);
        }

        public Transactions? getid(int id)
        {
            return _db.Transactions.FirstOrDefault(m => m.Transaction_id == id);
        }

        public Transactions? deletetransaction(int id)
        {
            Transactions? action = getid(id);
            _db.Transactions.Remove(action);
            return action;
        }

        public Transactions? updatetransaction(int id, Transactions transaction)
        {
            Transactions action = getid(id);
            transaction.Transaction_qty = action.Transaction_qty;
            transaction.product_id = action.product_id;
            transaction.store_location = action.store_location;
            return action;
        }
    }
}
