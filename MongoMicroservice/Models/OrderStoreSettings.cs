namespace MongoMicroservice.Models
{
    public class OrderStoreSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;

        public string OrderDbCollectionName { get; set; } = string.Empty;
    }
}
