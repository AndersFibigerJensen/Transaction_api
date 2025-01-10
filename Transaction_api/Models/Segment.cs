namespace Transaction_api.NewFolder
{
    public class Segment
    {
        public long transaction_id { get; set; }

        public int hour { get; set; }

        public int year { get; set; }

        public int weekday { get; set; }

        public int month { get; set; }

        public int Transaction_qty { get; set; }

        public int? store_location { get; set; }

        public int product_id { get; set; }

        public int? product_category { get; set; }

        public Segment(long transaction_id,int hour,int weekday,int month,int transaction_qty,int store_location,int product_id, int product_category)
        {
            
        }
    }
}
