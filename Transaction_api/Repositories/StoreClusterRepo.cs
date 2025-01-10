using Transaction_api.Context;
using Transaction_api.Models;
namespace Transaction_api.Repositories
{
    public class StoreClusterRepo
    {
        private string getSQL = "";
        private StoreClusterContext _context;

        public StoreClusterRepo(StoreClusterContext context)
        {
            _context = context;
        }

        public async Task<List<StoreCluster>> getall()
        {
            return null;
        }

    }
}
