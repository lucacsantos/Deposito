using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
{
    public class GetAllClientsQuery : IRequest<IEnumerable<CreateClientResponse>>
    {
    }
}
