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

        public async  Task<List<ProductCluster>> getall()
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
                        ProductCluster pro = new ProductCluster(productid, productname, productdetail,prod);
                        products.Add(pro);
                    }
                    return products;
                }
            }
    }
}
