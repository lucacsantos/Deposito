using Deposito.Domain.Commands.Responses.Products;
using MediatR;

namespace Deposito.Domain.Commands.Request.Product
{
    public class GetAllProductsQuery : IRequest<IEnumerable<CreateProductResponse>>
    {
    }
}
