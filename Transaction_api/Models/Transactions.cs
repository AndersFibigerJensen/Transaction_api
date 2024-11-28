namespace Transaction_api.NewFolder
{
    public class Transactions
    {
        public int Transaction_id { get; set; }

        public DateTime Transaction_date { get; set; }

        public DateTime Transaction_time { get; set; }

        public int Transaction_qty { get; set; }

        public string? store_location { get; set; }

        public int product_id { get; set; }



        public void hour_valid()
        {

        }
    }
}
