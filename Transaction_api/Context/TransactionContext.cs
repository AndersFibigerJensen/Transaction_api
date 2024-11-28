using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Transaction_api.NewFolder;
namespace Transaction_api.Context
{
    public class TransactionContext:DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options):base(options)
        {
            
        }

        public DbSet<Transactions> Transactions { get; set; }

    }
}
