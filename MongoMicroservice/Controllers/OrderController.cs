using Microsoft.AspNetCore.Mvc;
using MongoMicroservice.Data_Access;
using MongoMicroservice.Models;

namespace MongoMicroservice.Controllers
{
    public class OrderController:ControllerBase
    {
        private readonly Iorder _order;
        private readonly ILogger<OrderController> _logger;

        public OrderController(Iorder order)
        {
            _order = order;
            //_logger = logger;
        }

        [HttpGet]
        [Route("/getOrderId")]
        public async Task<IActionResult> getOrderById(string orderId)
        {
            var orderDetails = await _order.getOrderId(orderId);
            return Ok(orderDetails);
        }

        [HttpPost]
        [Route("/addOrder")]
        public async Task<IActionResult> addOrder([FromBody]OrderDetails order)
        {

            //_logger.LogInformation("logging the order to mongo db");
           var orderID= await _order.addOrder(order);
            OrderDetails orderDetails = await _order.getOrderId(orderID);
            return Ok(orderDetails);


            

        }
    }
}
