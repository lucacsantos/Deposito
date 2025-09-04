using Deposito.Domain.Entites;
using Google.Cloud.Firestore;

namespace Deposito.Services
{
    public class ProductFirestoreService
    {
        private readonly FirestoreDb _db;

        public ProductFirestoreService(FirestoreDb db)
        {
            _db = db;
        }

        public async Task AddProductAsync(Product product)
        {
            CollectionReference productsRef = _db.Collection("products");
            await productsRef.Document(product.Id.ToString()).SetAsync(product);
        }

        public async Task<Product?> GetProducsAsync(Guid id)
        {
            DocumentReference docRef = _db.Collection("products").Document(id.ToString());
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Product>();
            }
                
            return null;
        }
    }
}
