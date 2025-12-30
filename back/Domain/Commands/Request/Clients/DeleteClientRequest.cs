using MediatR;

namespace Deposito.Domain.Commands.Request
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
