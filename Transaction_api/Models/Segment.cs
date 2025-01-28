namespace Transaction_api.NewFolder
{
    public class Segment
    {
        public long Transaction_id { get; set; }

        public int Hour { get; set; }

        public int Year { get; set; }

        public int Weekday { get; set; }

        public int Month { get; set; }

        public int Transaction_qty { get; set; }

        public int? Store_location { get; set; }

        public int Product_id { get; set; }

        public int? Product_category { get; set; }

        public Segment(long transaction_id,int hour,int weekday,int month,int transaction_qty,int store_location,int product_id, int product_category)
        {
            Transaction_id = transaction_id;
            Hour = hour;
            Weekday = weekday;
            Month = month;
            Transaction_qty = transaction_qty;
            Store_location = store_location;
            Product_id = product_id;
            Product_category = product_category;
        }
    }
}
