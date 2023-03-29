using MediatR;
using ProductMicroservice.Data_Access;
using ProductMicroservice.Models;
using ProductMicroservice.Queries;
using ProductMicroservice.Repository;

namespace ProductMicroservice.Handler
{
    public class getProductByIdHandler : IRequestHandler<getProductByIdQuery, Products>
    {
        private readonly Iproduct _products;
        
        public getProductByIdHandler(Iproduct products)
        {
            _products = products;
        }
        public Task<Products> Handle(getProductByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_products.getProductById(request.id));
        }
    }
}
