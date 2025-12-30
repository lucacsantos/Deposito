using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Deposito.Services
{
    public class FirebaseInitializer
    {
        public static FirestoreDb InitializeFirestore()

        {
            var credential = GoogleCredential.FromFile("Services/firebase-key.json"); 

            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = credential
                });
            }

            var builder = new FirestoreClientBuilder
            {
                Credential = credential
            };

            return FirestoreDb.Create("deposito-db", builder.Build());

        }
    }
}