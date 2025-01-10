using Microsoft.EntityFrameworkCore;
using Transaction_api.Models;

namespace Transaction_api.Context
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }

        public DbSet<Product> products { get; set; }


    }
}
