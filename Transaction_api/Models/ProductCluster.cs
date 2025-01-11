namespace Transaction_api.Models
{
    public class ProductCluster
    {
        public int Transaction_id { get; set; }

        public int Hour { get; set; }

        public int Product_category { get; set; }

        public int Cluster_id { get; set; }

        public ProductCluster(int transaction_id,int hour,int product_category,int cluster_id)
        {
            Transaction_id = transaction_id;
            Hour = hour;
            Product_category = product_category;
            Cluster_id = cluster_id;

        }
    }
}
