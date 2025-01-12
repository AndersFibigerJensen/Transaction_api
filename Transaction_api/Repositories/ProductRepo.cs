using Microsoft.Data.SqlClient;
using Transaction_api.Context;
using Transaction_api.Models;

namespace Transaction_api.Repositories
{
    public class ProductRepo
    {
        private string getallproducts = "Select * from Products";
        private string getid = "Select * from Products where @ID";

        private ProductContext _context;

        public ProductRepo(ProductContext context)
        {
           _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> getall()
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getallproducts, connection))
                {
                    List<Product> products = new List<Product>();
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while(await reader.ReadAsync())
                    {
                        int productid = reader.GetInt32(0);
                        string productname = reader.GetString(1);
                        string productdetail= reader.GetString(2);
                        Product pro= new Product(productid, productname, productdetail);
                        products.Add(pro);
                    }
                    return products;
                }
            }
        }

        public async Task<Product> get(int id)
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getid, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        int productid = reader.GetInt16(0);
                        string productname = reader.GetString(1);
                        string productdetail = reader.GetString(2);
                        Product pro = new Product(productid, productname, productdetail);
                        return pro;
                    }
                }
                return null;
            }
        }

    }
}
