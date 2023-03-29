using MediatR;
using ProductMicroservice.Commands;
using ProductMicroservice.Data_Access;

namespace ProductMicroservice.Handler
{
    public class deleteProductHandler : IRequestHandler<deleteProductCommand, string>
    {

        private readonly Iproduct _product;

        public deleteProductHandler(Iproduct product)
        {
            _product = product;
        }
        public Task<string> Handle(deleteProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.deleteProduct(request.id));
        }
    }
}
