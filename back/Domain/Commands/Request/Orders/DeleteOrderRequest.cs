using MediatR;

namespace Deposito.Domain.Commands.Request
{
    public class DeleteOrderRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteOrderRequest(Guid id)
        {
            Id = id;
        }
    }
}
