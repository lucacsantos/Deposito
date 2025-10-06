using Deposito.Domain.Commands.Request.Product;
using Deposito.Domain.Commands.Responses.Products;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class GetAlllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<CreateProductResponse>>
    {
        private readonly ProductFirestoreService _productFirestoreService;

        public GetAlllProductsHandler(ProductFirestoreService productFirestoreService)
            => _productFirestoreService = productFirestoreService;
        public async Task<IEnumerable<CreateProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productFirestoreService.GetProductsAsync();

            var response = products.Select( p=> new CreateProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                ImageURL = p.ImageURL,
                Price = p.Price,
            });

            return response;
        }
    }
}
