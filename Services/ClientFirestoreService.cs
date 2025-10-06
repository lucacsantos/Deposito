using Deposito.Domain.Entites;
using Google.Cloud.Firestore;

namespace Deposito.Services
{
    public class ClientFirestoreService
    {
        private readonly FirestoreDb _db;

        public ClientFirestoreService(FirestoreDb db)
        {
            _db = db;
        }

        public async Task AddClientAsync(Client client)
        {
            CollectionReference clientRef = _db.Collection("client");
            await clientRef.Document(client.Id.ToString()).SetAsync(client);
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            CollectionReference clientsRef = _db.Collection("client");
            QuerySnapshot snapshots = await clientsRef.GetSnapshotAsync();

            var clients = new List<Client>();

            foreach (var item in snapshots.Documents)
            {
                if (item.Exists)
                {
                    if (item.Exists)
                        clients.Add(item.ConvertTo<Client>());
                }
            }
            return clients;
        }

        public async Task<Client?> GetClientAsyncId(Guid id)
        {
            DocumentReference docRef = _db.Collection("client").Document(id.ToString());
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Client>();
            }
            return null;
        }

        public async Task UpdateClientAsync(Client client)
        {
            DocumentReference docRef = _db.Collection("client").Document(client.Id.ToString());

            var update = new Dictionary<string, object>
            {
                { "FirstName", client.FirstName },
                { "LastName", client.LastName },
                { "Email", client.Email },
                { "Phone", client.Phone }
            };

            await docRef.UpdateAsync(update);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            DocumentReference docRef = _db.Collection("client").Document(id.ToString());
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            await docRef.DeleteAsync();
        }
    }
}
