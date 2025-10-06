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

        public async Task<Product?> GetProductsAsyncId(Guid id)
        {
            DocumentReference docRef = _db.Collection("products").Document(id.ToString());
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Product>();
            }

            return null;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            CollectionReference productRef = _db.Collection("products");
            QuerySnapshot snapshots = await productRef.GetSnapshotAsync();

            var products = new List<Product>();

            foreach (var item in snapshots.Documents)
            {
                if (item.Exists)
                    products.Add(item.ConvertTo<Product>());
            }

            return products;
        }

        public async Task UpdateProductAsync(Product product)
        {
            DocumentReference docRef = _db.Collection("products").Document(product.Id.ToString());

            var update = new Dictionary<string, object>
            {
                { "Name", product.Name },
                { "Price", product.Price },
                { "ImageURL", product.ImageURL },

            };

             await docRef.UpdateAsync(update);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            DocumentReference docRef = _db.Collection("products").Document(id.ToString());
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            await docRef.DeleteAsync();
        }
    }
}
