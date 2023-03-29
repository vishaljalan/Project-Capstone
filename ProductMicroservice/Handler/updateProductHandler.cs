using MediatR;
using ProductMicroservice.Commands;
using ProductMicroservice.Data_Access;

namespace ProductMicroservice.Handler
{
    public class updateProductHandler : IRequestHandler<updateProductCommand, string>
    {

        private readonly Iproduct _product;

        public updateProductHandler(Iproduct product)
        { 
            _product = product;
        
        }
        public Task<string> Handle(updateProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.updateProduct(request.product));
        }
    }
}
