using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
{
    public class GetOrderByIdQuery : IRequest<CreateOrderResponse>
    {
        public Guid Id { get; set; }

        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
