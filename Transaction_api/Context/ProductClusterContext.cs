using Microsoft.EntityFrameworkCore;
using Transaction_api.Models;

namespace Transaction_api.Context
{
    public class ProductClusterContext:DbContext
    {
        public ProductClusterContext(DbContextOptions<ProductClusterContext> options) : base(options)
        {

        }

        public DbSet<ProductCluster> categoriclusters { get; set; }
    }
}
