namespace Transaction_api.Models
{
    public class Store
    {
        public int Store_id { get; set; }

        public string Store_location { get; set; }

        public Store(int store_id,string store_location)
        {
            Store_id = store_id;
            Store_location = store_location;
        }

    }
}
