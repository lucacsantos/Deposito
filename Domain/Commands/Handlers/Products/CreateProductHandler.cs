using Deposito.Domain.Commands.Request.Product;
using Deposito.Domain.Commands.Responses.Products;
using Deposito.Domain.Entites;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly ProductFirestoreService _productFirestoreService;

        public CreateProductHandler(ProductFirestoreService productFirestoreService)
            => _productFirestoreService = productFirestoreService;

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Price = request.Price,
                ImageURL = request.ImageURL
            };

           await _productFirestoreService.AddProductAsync(product);

            return new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageURL = product.ImageURL
            };
        }
    }
}
