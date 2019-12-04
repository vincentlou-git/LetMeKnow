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

        // https://firebase.google.com/docs/auth/android/email-link-auth
        private ActionCodeSettings GetActionCodeSettings(string email) {
            return ActionCodeSettings.NewBuilder()
                // URL you want to redirect back to. The domain (www.example.com) for this
                // URL must be whitelisted in the Firebase Console.
                .SetUrl("www.google.com")
                // This must be true
                .SetHandleCodeInApp(true)
                .SetIOSBundleId("com.example.ios")
                .SetAndroidPackageName(
                        "com.example.android",
                        true,   /* installIfNotAvailable */
                        "12"    /* minimumVersion */)
                .Build();
            //var user = FirebaseAuth.Instance.SendPasswordResetEmail(email, actionCodeSettings);
            //var token = await user.get(false);
            //return token.Token;
            // Log.d(TAG, "Email sent.");
        }

        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<DatabaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
        }
    }
}