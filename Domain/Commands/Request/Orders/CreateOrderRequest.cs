using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public string Addres { get; set; } = string.Empty;
        public bool InStorePickup { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        // public Product? ProductId { get; set; } DEPOIS TEM QUE VER COMO VAI SER TRATADO
        // public Client? ClientId { get; set; } DEPOIS TEM QUE VER COMO VAI SER TRATADO
    }
}
