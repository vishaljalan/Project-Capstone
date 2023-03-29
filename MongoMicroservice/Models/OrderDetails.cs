using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoMicroservice.Models
{
    public class OrderDetails
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public int userId { get; set; }
        
        public string name { get; set; }

       
        public string email { get; set; }

        public string address { get; set; }

        public int total { get; set; }
        public List<Product> products { get; set; }
    }

    public class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
