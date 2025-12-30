using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly ProductFirestoreService _productFirestoreService;

        public UpdateProductHandler(ProductFirestoreService productFirestoreService)
            => _productFirestoreService = productFirestoreService;

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productFirestoreService.GetProductsAsyncId(request.Id);

            if (product is null)
                throw new Exception("Produto não encontrado.");

            product.Name = request.Name;
            product.Price = request.Price;
            product.ImageURL = request.ImageURL;

            await _productFirestoreService.UpdateProductAsync(product);

            return new UpdateProductResponse
            {
                Id = Guid.Parse(product.Id),
                Name = product.Name,
                Price = product.Price,
                ImageURL = product.ImageURL
            };
        }
    }
}
