using Deposito.Domain.Entites;
using Google.Cloud.Firestore;

namespace Deposito.Services
{
    public class OrderFirestoreService
    {
        private readonly FirestoreDb _db;

        public OrderFirestoreService(FirestoreDb db)
        {
            _db = db;
        }

        public async Task AddOrderAsync(Order order)
        {
            CollectionReference orderRef = _db.Collection("order");
            await orderRef.Document(order.Id.ToString()).SetAsync(order);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            CollectionReference orderRef = _db.Collection("order");
            QuerySnapshot snapshots = await orderRef.GetSnapshotAsync();

            var order = new List<Order>();

            foreach (var item in snapshots.Documents)
            {
                if (item.Exists)
                    order.Add(item.ConvertTo<Order>());
            }

            return order;
        }

        public async Task<Order?> GetOrderAsyncId(Guid id) 
        {
            DocumentReference orderRef = _db.Collection("order").Document(id.ToString());
            DocumentSnapshot snapshot = await orderRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Order>();
            }

            return null;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            DocumentReference orderRef = _db.Collection("order").Document(order.Id.ToString());

            var update = new Dictionary<string, object>
            {
                { "Addres", order.Addres },
                { "InStorePickup", order.InStorePickup },
                { "PaymentMethod", order.PaymentMethod },
                { "Status", order.Status }
            };

             await orderRef.UpdateAsync(update);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            DocumentReference orderRef = _db.Collection("order").Document(id.ToString());
            DocumentSnapshot snapshot = await orderRef.GetSnapshotAsync();
            await orderRef.DeleteAsync();
        }
    }
}
