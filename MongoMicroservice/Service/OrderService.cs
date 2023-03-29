using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoMicroservice.Data_Access;
using MongoMicroservice.Models;

namespace MongoMicroservice.Service
{
    public class OrderService: Iorder
    {
        private readonly IMongoCollection<OrderDetails> _orderCollection;

        public OrderService(IOptions<OrderStoreSettings> orderStoreSettings)
        {
            var mongoClient = new MongoClient(orderStoreSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(orderStoreSettings.Value.DatabaseName);

            _orderCollection = mongoDatabase.GetCollection<OrderDetails>(orderStoreSettings.Value.OrderDbCollectionName);

        }

        public async Task<string> addOrder(OrderDetails order)
        {
            await _orderCollection.InsertOneAsync(order);
            return order.id;
           
        }

        public async Task<OrderDetails> getOrderId(string orderId)
        {
           return await _orderCollection.Find(x=>x.id == orderId).FirstOrDefaultAsync();
        }
    }
}
