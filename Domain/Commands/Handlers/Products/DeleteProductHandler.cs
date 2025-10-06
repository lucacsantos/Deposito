using Deposito.Domain.Commands.Request.Product;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, Unit>
    {
        private readonly ProductFirestoreService _productFirestoreService;

        public DeleteProductHandler(ProductFirestoreService productFirestoreService)
        {
            _productFirestoreService = productFirestoreService;
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productFirestoreService.GetProductsAsyncId(request.Id);

            if (product is null)
                throw new Exception("Produto não encontrado");

            await _productFirestoreService.DeleteProductAsync(request.Id);

            return Unit.Value;
        }
    }
}
