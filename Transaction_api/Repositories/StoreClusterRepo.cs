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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="cluster"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<List<StoreCluster>> getall(int store=0,int cluster=0,int category=0)
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
                    if(store!=0)
                    {
                        storeClusters=storeClusters.Where(a => a.Store_id == store).ToList();
                    }
                    if(cluster!=0)
                    {
                        storeClusters = storeClusters.Where(a => a.Cluster_id == cluster).ToList();
                    }
                    if(category!=0)
                    {
                        storeClusters.Where(a => a.Product_category == category).ToList();
                    }
                    return storeClusters;
                }
            }
        }

    }
}
