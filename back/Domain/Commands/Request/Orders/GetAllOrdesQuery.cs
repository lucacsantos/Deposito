using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
{
    public class GetAllOrdesQuery : IRequest<IEnumerable<CreateOrderResponse>>
    {
    }
}
