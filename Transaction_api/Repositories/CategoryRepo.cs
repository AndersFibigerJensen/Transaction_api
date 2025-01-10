using Microsoft.Data.SqlClient;
using System;
using Transaction_api.Context;
using Transaction_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transaction_api.Repositories
{
    public class CategoryRepo
    {

        private readonly CategoryContext _context;
        private string getid = "Select * from product_category where Product_category_id=@ID";

        public CategoryRepo(CategoryContext context)
        {
            _context = context;
        }

        public async Task<List<Product_category>> getall()
        {
            using(SqlConnection connection= new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getid, connection))
                {

                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        int productid = reader.GetInt16(0);
                        string productname = reader.GetString(1);
                        string productdetail = reader.GetString(2);
                    }
                }
                return null;
            }

        }

        public async Task<Product_category> getstore(int id)
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getid, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while(await reader.ReadAsync())
                    {
                        int productid = reader.GetInt32(0);
                        string productname = reader.GetString(1);
                        Product_category cat = new Product_category(productid,productname);
                        return cat;
                    }
                }
                return null;
            }
        }




    }
}
