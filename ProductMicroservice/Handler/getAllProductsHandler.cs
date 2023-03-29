using MediatR;
using ProductMicroservice.Data_Access;
using ProductMicroservice.Models;
using ProductMicroservice.Queries;

namespace ProductMicroservice.Handler
{
    public class getAllProductsHandler : IRequestHandler<getAllProductsQuery, List<Products>>
    {
        private readonly Iproduct _product;

        public getAllProductsHandler(Iproduct product)
        {
            _product = product;
        }
        public Task<List<Products>> Handle(getAllProductsQuery request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_product.getAllProducts());
        }
    }
}
