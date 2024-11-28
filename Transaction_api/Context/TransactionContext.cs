using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Transactionsclass;
namespace Transaction_api.Context
{
    public class TransactionContext:DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options):base(options)
        {
            
        }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
