using Google.Cloud.Firestore;

namespace Deposito.Domain.Entites
{
    [FirestoreData]
    public class Product
    {
        [FirestoreDocumentId]
        public string Id { get; set;} = string.Empty;

        [FirestoreProperty]
        public string Name { get; set; } = string.Empty;

        [FirestoreProperty]
        public double Price { get; set; }

        [FirestoreProperty]
        public string ImageURL { get; set; } = string.Empty;
    }
}
