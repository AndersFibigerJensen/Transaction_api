namespace Transaction_api.Models
{
    public class Product
    {
        public int Product_id { get; set; }

        public string Product_detail { get; set; }

        public string Product_type { get; set; }

        public Product(int product_id,string product_detail,string product_type)
        {
            Product_id=product_id;
            Product_detail=product_detail;
            Product_type=product_type;
        }
    }
}
