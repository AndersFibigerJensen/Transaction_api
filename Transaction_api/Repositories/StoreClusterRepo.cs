using Microsoft.Data.SqlClient;
using Transaction_api.Context;
using Transaction_api.Models;
namespace Transaction_api.Repositories
{
    public class StoreClusterRepo
    {
        private string getSQL = "select * from";
        private StoreClusterContext _context;

        public StoreClusterRepo(StoreClusterContext context)
        {
            _context = context;
        }

        public async Task<List<StoreCluster>> getall()
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getSQL, connection))
                {
                    List<StoreCluster> storeClusters = new List<StoreCluster>();
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        int productid = reader.GetInt32(0);
                        int productname = reader.GetInt32(1);
                        int productdetail = reader.GetInt32(2);
                        int prod = reader.GetInt32(3);
                        StoreCluster pro = new StoreCluster(productid, productname, productdetail, prod);
                        storeClusters.Add(pro);
                    }
                    return storeClusters;
                }
            }
        }

    }
}
