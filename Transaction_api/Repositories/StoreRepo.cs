using Microsoft.Data.SqlClient;
using Transaction_api.Context;
using Transaction_api.Models;

namespace Transaction_api.Repositories
{
    public class StoreRepo
    {
        private string getall = "select * from Stores";
        private string get = "Select * from Stores where store_id=@ID";

        private StoreContext _context;

        public StoreRepo(StoreContext Context)
        {
            _context = Context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Store>> getstores()
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getall, connection))
                {
                    List<Store> stores = new List<Store>();
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while(await reader.ReadAsync())
                    {
                        int storeid = reader.GetInt32(0);
                        string storename = reader.GetString(1);
                        Store store = new Store(storeid, storename);
                        stores.Add(store);
                    }
                    return stores;

                }
            }
            
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Store?> getstore(int id)
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(get, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        int storeid =reader.GetInt32(0);
                        string storename =reader.GetString(1);
                        Store store = new Store(storeid, storename);
                        return store;
                    }

                }
            }
            return null;
        }

    }
}
