using MediatR;
using ProductMicroservice.Data_Access;
using ProductMicroservice.Models;
using ProductMicroservice.Queries;

namespace ProductMicroservice.Handler
{
    public class getAllProductsByCategoryIdHandler : IRequestHandler<getAllProductsByCategoryIdQuery, List<Products>>
    {

        private readonly Iproduct _product;

        public getAllProductsByCategoryIdHandler(Iproduct product)
        {
            _product = product;
        }

        public Task<List<Products>> Handle(getAllProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.getProductsByCategory(request.id));
        }
    }
}
