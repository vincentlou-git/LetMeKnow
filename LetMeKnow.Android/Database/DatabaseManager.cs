using Autofac;

using Android.App;

using Firebase;
using Firebase.Database;
using Firebase.Auth;

using LetMeKnow.Interfaces;

namespace LetMeKnow.Droid.Database {
    public class DatabaseManager : Module {
        public static FirebaseDatabase GetDatabase() {

            // Initialize connection to our firebase server with options obtained from google-services.json
            var option = new Firebase.FirebaseOptions.Builder()
                    .SetApplicationId("letmeknow-439fb")
                    .SetApiKey("AIzaSyCYFnJlyfMDve4O1A0hRmu5VRPds0m79AM")
                    .SetDatabaseUrl("https://letmeknow-439fb.firebaseio.com")
                    .SetStorageBucket("letmeknow-439fb.appspot.com")
                    .Build();
            var app = FirebaseApp.InitializeApp(Application.Context, option);
            if (app != null) {
                // Successful init
                return FirebaseDatabase.GetInstance(app);
            }

            // Fail init
            return null;
        }

        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<DatabaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
        }
    }
}