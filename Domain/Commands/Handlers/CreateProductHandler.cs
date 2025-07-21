using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handler
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        public static readonly List<Product> products = new();

        public Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                ImageURL = request.ImageURL
            };

            products.Add(product);

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
