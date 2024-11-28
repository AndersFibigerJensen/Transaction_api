namespace Transaction_api
{
    public class Secret
    {
        private static readonly string _secret = "Server =MSI; Database =CustomerProductOrderDB;Integrated Security=True;TrustServerCertificate=True";

        public static string secret { get { return _secret; } }
    }
}
