namespace Deposito.Domain.Entites
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Addres { get; set; } = string.Empty;
        public bool InStorePickup { get; set; } 
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public Product ProductId { get; set; } 
        public Client ClientId { get; set; }
    }
}
