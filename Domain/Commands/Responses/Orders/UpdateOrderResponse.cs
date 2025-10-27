namespace Deposito.Domain.Commands.Responses
{
    public class UpdateOrderResponse
    {
        public Guid Id { get; set; }
        public string Addres { get; set; } = string.Empty;
        public bool InStorePickup { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
