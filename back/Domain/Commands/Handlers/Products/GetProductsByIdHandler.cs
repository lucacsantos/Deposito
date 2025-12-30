using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class GetProductsByIdHandler : IRequestHandler<GetProductByIdQuery, CreateProductResponse>
    {
        private readonly ProductFirestoreService _productFirestoreService;

        public GetProductsByIdHandler(ProductFirestoreService productFirestoreService) 
            => _productFirestoreService = productFirestoreService;

        public async Task<CreateProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productFirestoreService.GetProductsAsyncId(request.Id); 
           
            if (product is null)
                throw new Exception("Produto não encontrado");

            return new CreateProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageURL = product.ImageURL
            };
        }
    }
}