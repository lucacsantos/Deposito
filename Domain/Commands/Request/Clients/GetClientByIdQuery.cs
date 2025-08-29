using Deposito.Domain.Commands.Responses.Clients;
using MediatR;

namespace Deposito.Domain.Commands.Request.Clients
{
    public class GetClientByIdQuery : IRequest<CreateClientResponse>
    {
        public Guid Id { get; set; }

        public GetClientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
