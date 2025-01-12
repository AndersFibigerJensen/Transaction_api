using Microsoft.Data.SqlClient;
using System;
using Transaction_api.Context;
using Transaction_api.Models;
using Transaction_api.NewFolder;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Collections.Specialized.BitVector32;
namespace Transaction_api.Repositories
{
    public class TransactionRepo
    {
        private TransactionContext _db;

        private string getpost = "Select * from Segment where Transaction_id=@ID";
        private string addpost = "Insert into Segment (Transaction_id,Transaction_hour,Transaction_month,Transaction_weekday,Transaction_qty,Store_id_inp1,product_id_inp1,product_category_inp1) values(@id,@hour,@month,@weekday,@qty,@storeid,@productid,@category)";
        private string deletepost = "Delete from Segment where Transaction_id=@ID";
        private string updatepost = "update Segment set Transaction_hour=@hour,Transaction_month=@month,Transaction_weekday=@weekday," +
            "Transaction_qty=@qty,Store_id_inp1=@storeid,product_id_inp1=@productid,product_category_inp1=@category where Transaction_id=@id";
        private string getmax = "select max(Transaction_id) from Segment";

        public TransactionRepo(TransactionContext dbcontext)
        {
            _db = dbcontext;
        }

        
        /// <summary>
        /// bruges til at hente skrive en nye transaktion ind i datbasen
        /// </summary>
        /// <param name="action">den nye segment</param>
        /// <returns></returns>
        public async Task add(Segment action)
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(addpost, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@ID",maxid().Result);
                        command.Parameters.AddWithValue("hour",action.hour);
                        command.Parameters.AddWithValue("@month",action.month);
                        command.Parameters.AddWithValue("@weekday", action.weekday);
                        command.Parameters.AddWithValue("@qty",action.Transaction_qty);
                        command.Parameters.AddWithValue("@storeid",action.store_location);
                        command.Parameters.AddWithValue("@productid",action.product_id);
                        command.Parameters.AddWithValue("@category",action.product_category);
                        await command.Connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }

        /// <summary>
        /// bruges til hente en transaktion ud fra transaktionens unikke id
        /// </summary>
        /// <param name="id">bruges til indsætte det unikke id</param>
        /// <returns> returnere transaktionen med det unikke id</returns>
        public async Task<Segment?> getid(int id)
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(getpost, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        await command.Connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        if (reader.Read())
                        {
                            long segmentid = reader.GetInt64(0);
                            int hour = reader.GetInt32(1);
                            int month = reader.GetInt32(2);
                            int weekday= reader.GetInt32(3);
                            int qty = reader.GetInt32(4);
                            int store_id = reader.GetInt32(5);
                            int product_id = reader.GetInt32(6);
                            int category = reader.GetInt32(7);
                            Segment seg= new Segment(segmentid,hour,month,weekday,qty,store_id,product_id,category);
                            return seg;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return null;
            }
        }

        /// <summary>
        /// bruges til at slette en transaktion
        /// </summary>
        /// <param name="id"> bruges til at finde en transaktion ud fra id</param>
        /// <returns> returnere det segment som er blevet slettet</returns>
        public async Task<Segment?> deletetransaction(int id)
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(deletepost, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@ID",id);
                        await command.Connection.OpenAsync() ;
                        await command.ExecuteNonQueryAsync();

                    }
                    catch(SqlException sql)
                    {

                    }
                    catch (Exception ex)
                    {

                    }
                }
                return null;    

            }
        }

        public async Task<Segment?> updatetransaction(int id, Segment action)
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(updatepost, connection))
                {
                    try
                    {

                        command.Parameters.AddWithValue("hour", action.hour);
                        command.Parameters.AddWithValue("@month", action.month);
                        command.Parameters.AddWithValue("@weekday", action.weekday);
                        command.Parameters.AddWithValue("@qty", action.Transaction_qty);
                        command.Parameters.AddWithValue("@storeid", action.store_location);
                        command.Parameters.AddWithValue("@productid", action.product_id);
                        command.Parameters.AddWithValue("@category", action.product_category);
                        await command.Connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        if (reader.Read())
                        {
                            long segmentid = reader.GetInt64(0);
                            int hour = reader.GetInt16(1);
                            int month = reader.GetInt16(2);
                            int weekday = reader.GetInt16(3);
                            int qty = reader.GetInt16(4);
                            int store_id = reader.GetInt16(5);
                            int product_id = reader.GetInt32(6);
                            int category = reader.GetInt16(7);
                            Segment seg = new Segment(segmentid, hour, month, weekday, qty, store_id, product_id, category);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return null;
        }

        public async Task<int> maxid()
        {
            using (SqlConnection connection = new SqlConnection(Secret.secret))
            {
                using (SqlCommand command = new SqlCommand(updatepost, connection))
                {
                    try
                    {
                        await command.Connection.OpenAsync();
                        SqlDataReader reader= await command.ExecuteReaderAsync();
                        if(reader.Read())
                        {
                            int maxid = reader.GetInt32(0);
                            return maxid;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return 0;

            }
        }
    }
}
