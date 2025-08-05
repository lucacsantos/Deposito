using Deposito.Domain.Commands.Handlers;
using Deposito.Domain.Commands.Request.Product;
using Deposito.Domain.Commands.Responses.Product;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class GetProductsByIdHandler : IRequestHandler<GetProductByIdQuery, CreateProductResponse>
    {
        private static readonly List<Product> products = CreateProductHandler.products;
       
        public Task<CreateProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = products.FirstOrDefault(p => p.Id == request.Id);

            if (product is null)
                throw new Exception("Produto não encontrado");

            return Task.FromResult(new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageURL = product.ImageURL
            });
        }
    }
}