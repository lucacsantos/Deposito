using MediatR;

namespace Deposito.Domain.Commands.Request.Clients
{
    public class DeleteClientRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteClientRequest(Guid id)
        {
            Id = id;
        }
    }
}
