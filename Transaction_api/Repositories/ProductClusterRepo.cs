using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Transaction_api.Context;
using Transaction_api.Models;
namespace Transaction_api.Repositories
{
    public class ProductClusterRepo
    {
        private ProductClusterContext _context;
        
        private string getallSQL = "select * from product_cluster";
        private string StoreDistinct = "select distinct(Store_id) from StoreCluster";
        private string categoryDistinct = "select distinct(product_category) from StoreCluster";
        private string clusterDistinct = "select distinct(cluster_id) from StoreCluster";


        public ProductClusterRepo(ProductClusterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// henter data ud fra den information som er givet
        /// </summary>
        /// <param name="category_id"></param>
        /// <param name="cluster_id"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public async Task<int> getall(int category_id = 0, int cluster_id = -1, int hour = 0)
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getallSQL, connection))
                {
                    List<ProductCluster> products = new List<ProductCluster>();
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        long productid = reader.GetInt64(0);
                        int productname = reader.GetInt32(1);
                        int productdetail = reader.GetInt32(2);
                        bool read = reader.IsDBNull(3);
                        int prod = 0;
                        if (read == true)
                        {
                            prod = 0;
                        }
                        else
                            prod = reader.GetInt32(3);
                        ProductCluster pro = new ProductCluster(productid, productname, productdetail, prod);
                        products.Add(pro);
                    }
                    if(category_id!=0)
                    {
                        products=products.Where(a => a.Product_category ==category_id).ToList();
                    }
                    if(cluster_id!=-1)
                    {
                        products=products.Where(a=>a.Cluster_id == cluster_id).ToList();
                    }
                    if(hour!=0)
                    {
                        products=products.Where(a => a.Hour == hour).ToList();
                    }
                    return products.Count;
                }
            }
        }
    }
}
