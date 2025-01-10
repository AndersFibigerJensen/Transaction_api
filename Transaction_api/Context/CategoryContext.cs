using Microsoft.EntityFrameworkCore;
using Transaction_api.Models;
using Transaction_api.NewFolder;

namespace Transaction_api.Context
{
    public class CategoryContext:DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options):base(options)
        {
            
        }

        public DbSet<Product_category> categories { get; set; }
    }
}
