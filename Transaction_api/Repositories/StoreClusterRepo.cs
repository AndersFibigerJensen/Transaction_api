using Microsoft.Data.SqlClient;
using Transaction_api.Context;
using Transaction_api.Models;
namespace Transaction_api.Repositories
{
    public class StoreClusterRepo
    {
        private string getSQL = "select * from StoreCluster";
        private string StoreDistinct = "select distinct(Store_id) from StoreCluster";
        private string categoryDistinct = "select distinct(product_category) from StoreCluster";
        private string clusterDistinct = "select distinct(cluster_id) from StoreCluster";


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
        public async Task<int> getall(int store=0,int cluster=0,int category=0)
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
                        long productid = reader.GetInt64(0);
                        int productname = reader.GetInt32(1);
                        int productdetail = reader.GetInt32(2);
                        bool read=reader.IsDBNull(3);
                        int prod = 0;
                        if (read==true)
                        {
                            prod = 0;
                        }
                        else
                            prod = reader.GetInt32(3);
                        StoreCluster pro = new StoreCluster(productid, productname, productdetail, prod);
                        storeClusters.Add(pro);
                    }
                    if(store!=0)
                    {
                        storeClusters=storeClusters=storeClusters.Where(a => a.Store_id == store).ToList();
                    }
                    if(cluster!=0)
                    {
                        storeClusters = storeClusters.Where(a => a.Cluster_id == cluster).ToList();
                    }
                    if(category!=0)
                    {
                        storeClusters = storeClusters.Where(a => a.Product_category == category).ToList();
                    }
                    return storeClusters.Count;
                }
            }
        }

        public async Task<List<int>> getstores()
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(StoreDistinct, connection))
                {
                    List<int> Storeids= new List<int>();
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        int id=reader.GetInt32(0);
                        Storeids.Add(id);
                    }
                    return Storeids;
                }
            }
        }

        public async Task<List<int>> getClusters()
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(clusterDistinct, connection))
                {
                    List<int> Clusters = new List<int>();
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        int id = reader.GetInt32(0);
                        Clusters.Add(id);
                    }
                    return Clusters;
                }
            }
        }

        public async Task<List<int>> getCategories()
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getSQL, connection))
                {
                    List<int> categories = new List<int>();
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        int id = reader.GetInt32(0);
                        categories.Add(id);
                    }
                    return categories;
                }
            }
        }

    }
}
