using MediatR;

namespace Deposito.Domain.Commands.Request.Product
{
    public class DeleteProductRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteProductRequest(Guid id)
        {
            Id = id;
        }
    }
}
