using Google.Cloud.Firestore;

namespace Deposito.Domain.Entites
{
    [FirestoreData]
    public class Client
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string FirstName { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string LastName { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string Email { get; set; } = string.Empty;
        
        [FirestoreProperty] 
        public string Phone {  get; set; } = string.Empty;

    }
}
