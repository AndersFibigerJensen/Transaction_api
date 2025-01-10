using Microsoft.EntityFrameworkCore;
using Transaction_api.Models;

namespace Transaction_api.Context
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Store> Stores { get; set; }
    }
}
