using Microsoft.EntityFrameworkCore;
using Transaction_api.Models;

namespace Transaction_api.Context
{
    public class StoreClusterContext:DbContext
    {
        public StoreClusterContext(DbContextOptions<StoreClusterContext> options) : base(options)
        {

        }

        public DbSet<StoreCluster> storeClusters { get; set; }
    }
}
