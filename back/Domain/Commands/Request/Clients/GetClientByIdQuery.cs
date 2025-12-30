using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
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
