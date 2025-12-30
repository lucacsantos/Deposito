
namespace Deposito.Domain.Commands.Responses
{
    public class CreateOrderResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Addres { get; set; } = string.Empty;
        public bool InStorePickup { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
       // public Product? ProductId { get; set; } DEPOIS TEM QUE VER COMO VAI SER TRATADO
       // public Client? ClientId { get; set; } DEPOIS TEM QUE VER COMO VAI SER TRATADO
    }
}
