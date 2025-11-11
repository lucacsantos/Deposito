using Google.Cloud.Firestore;

namespace Deposito.Domain.Entites
{
    [FirestoreData]
    public class Order
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;

        [FirestoreProperty]
        public string Address { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public bool InStorePickup { get; set; }
        
        [FirestoreProperty]
        public string PaymentMethod { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string Status { get; set; } = string.Empty;
        // public Product? ProductId { get; set; } DEPOIS TEM QUE VER COMO VAI SER TRATADO
        // public Client? ClientId { get; set; } DEPOIS TEM QUE VER COMO VAI SER TRATADO
    }
}
