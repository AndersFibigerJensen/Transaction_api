using Transaction_api.Context;

namespace Transaction_api.Repositories
{
    public class TransactionRepo
    {
        private TransactionContext _context;

        public TransactionRepo(TransactionContext dbcontext)
        {
            _context = dbcontext;
        }
    }
}
