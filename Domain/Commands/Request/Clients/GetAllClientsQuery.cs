using Deposito.Domain.Commands.Responses.Clients;
using MediatR;

namespace Deposito.Domain.Commands.Request.Clients
{
    public class GetAllClientsQuery : IRequest<IEnumerable<CreateClientResponse>>
    {
    }
}
