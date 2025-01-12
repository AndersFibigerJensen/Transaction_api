using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Transaction_api.Context;
using Transaction_api.Models;
namespace Transaction_api.Repositories
{
    public class ProductClusterRepo
    {
        private ProductClusterContext _context;
        
        private string getallSQL = "select * from ";


        public ProductClusterRepo(ProductClusterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category_id"></param>
        /// <param name="cluster_id"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public async Task<List<ProductCluster>> getall(int category_id = 0, int cluster_id = 0, int hour = 0)
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
                        int productid = reader.GetInt32(0);
                        int productname = reader.GetInt32(1);
                        int productdetail = reader.GetInt32(2);
                        int prod = reader.GetInt32(3);
                        ProductCluster pro = new ProductCluster(productid, productname, productdetail, prod);
                        products.Add(pro);
                    }
                    if(category_id==0)
                    {
                        products.Where(a => a.Cluster_id == cluster_id).ToList();
                    }
                    if(cluster_id==0)
                    {
                        products.Where(a=>a.Cluster_id == hour).ToList();
                    }
                    if(hour==0)
                    {
                        products.Where(a => a.Hour == hour).ToList();
                    }
                    return products;
                }
            }
        }
    }
}
