using MongoMicroservice.Models;

namespace MongoMicroservice.Data_Access
{
    public interface Iorder
    {
        public  Task<string> addOrder(OrderDetails order);
        public Task<OrderDetails> getOrderId(string userId);

        
    }
}
