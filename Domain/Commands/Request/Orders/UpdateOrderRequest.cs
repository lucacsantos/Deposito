using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
{
    public class UpdateOrderRequest : IRequest<UpdateOrderResponse>
    {
        public Guid Id { get; set; }
        public string Addres { get; set; } = string.Empty;
        public bool InStorePickup { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
