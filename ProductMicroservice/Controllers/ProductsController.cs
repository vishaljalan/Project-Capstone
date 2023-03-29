using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Commands;
using ProductMicroservice.Models;
using ProductMicroservice.Models.dto;
using ProductMicroservice.Queries;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("/getAllProducts")]
        public async Task<IActionResult> getAllProducts() 
        {
           
            var productsList = await _mediator.Send(new getAllProductsQuery());
            return Ok(productsList);
        
        }


        [HttpGet]
        [Route("/getProductById/{id}")]
        public async Task<IActionResult> getProductById(int id)
        {
            var product = await _mediator.Send(new getProductByIdQuery(id));
            return Ok(product);
        }

        [HttpGet]
        [Route("/getProductByCategory/{id}")]

        public async Task<IActionResult> getProductByCategoryId(int id)
        {
            var productList = await _mediator.Send(new getAllProductsByCategoryIdQuery(id));
            return Ok(productList);
        }


        [HttpPost]
        [Route("/addNewProduct")]
        public async Task<IActionResult> addNewProduct([FromBody]Productdto product)
        {
            await _mediator.Send(new addNewProductCommand(product));
            return StatusCode(200);
        }
        [HttpDelete]
        [Route("/deleteProduct/{id}")]
        public async Task<IActionResult> deleteProduct(int id)
        {
            await _mediator.Send(new deleteProductCommand(id));
            return StatusCode(200);
        }


        [HttpPut]
        [Route("/updateProduct")]
        public async Task<IActionResult> updateProduct([FromBody] Productdto product)
        {
            await _mediator.Send(new updateProductCommand(product));
            return StatusCode(200);
        }
        



    }
}
