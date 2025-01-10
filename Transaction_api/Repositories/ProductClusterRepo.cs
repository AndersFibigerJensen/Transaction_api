using Transaction_api.Context;
using Transaction_api.Models;
namespace Transaction_api.Repositories
{
    public class ProductClusterRepo
    {
        private ProductClusterContext _context;
        
        private string getallSQL = "";


        public ProductClusterRepo(ProductClusterContext context)
        {
            _context = context;
        }

        public async  Task<List<ProductCluster>> getall()
        {
            return null;
        }
    }
}
