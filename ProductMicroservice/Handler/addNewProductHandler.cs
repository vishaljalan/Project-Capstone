using MediatR;
using ProductMicroservice.Commands;
using ProductMicroservice.Data_Access;

namespace ProductMicroservice.Handler
{
    public class addNewProductHandler : IRequestHandler<addNewProductCommand, string>
    {

        private readonly Iproduct _product;

        public addNewProductHandler(Iproduct product)
        {
            _product = product;
        }


        public Task<string> Handle(addNewProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.addNewProduct(request.product));
        }
    }
}
