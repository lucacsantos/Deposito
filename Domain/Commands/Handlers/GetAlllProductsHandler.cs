using Deposito.Domain.Commands.Handler;
using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class GetAlllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<CreateProductResponse>>
    {
        private static readonly List<Product> products = CreateProductHandler.products;

        public Task<IEnumerable<CreateProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var response = products.Select(p => new CreateProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                ImageURL = p.ImageURL,
                Price = p.Price,
            });

                return Task.FromResult(response);
        }
    }
}
