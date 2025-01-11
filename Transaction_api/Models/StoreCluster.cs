namespace Transaction_api.Models
{
    public class StoreCluster
    {
        public int Transaction_id { get; set; }

        public int Store_id { get; set; }

        public int Product_category { get; set; }

        public int Cluster_id { get; set; }

        public StoreCluster(int id,int store_id,int category_id,int cluster_id)
        {
            Transaction_id = id;
            Store_id = store_id;
            Product_category = category_id;
            Cluster_id = cluster_id;
            
        }
    }
}
