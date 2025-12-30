using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
{
    public class GetAllProductsQuery : IRequest<IEnumerable<CreateProductResponse>>
    {
    }
}
