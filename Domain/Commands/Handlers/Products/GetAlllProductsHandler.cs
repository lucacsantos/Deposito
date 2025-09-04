using Deposito.Domain.Commands.Handlers;
using Deposito.Domain.Commands.Request.Product;
using Deposito.Domain.Commands.Responses.Products;
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
                Id = Guid.Parse(p.Id),
                Name = p.Name,
                ImageURL = p.ImageURL,
                Price = p.Price,
            });

                return Task.FromResult(response);
        }
    }
}
