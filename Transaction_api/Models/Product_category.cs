namespace Transaction_api.Models
{
    public class Product_category
    {
        public string category { get; set; }

        public int Product_category_id { get; set; }

        public Product_category(int id,string cat)
        {
            Product_category_id = id;
            category = cat;
        }

    }
}
