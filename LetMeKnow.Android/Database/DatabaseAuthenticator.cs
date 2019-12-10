using System.Threading.Tasks;
using Android.Util;
using Firebase.Auth;

using LetMeKnow.Interfaces;

namespace LetMeKnow.Droid.Database {
    public class DatabaseAuthenticator : IFirebaseAuthenticator {

        public async Task<string> LoginWithEmailAndPassword(string email, string password) {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public async Task<bool> RegisterWithEmail(string email) {
            var instance = FirebaseAuth.Instance;
            if (instance == null) {
                Log.Warn("FirebaseAuth", "Null instance");
                //return false;
            }

            var user = await instance.CreateUserWithEmailAndPasswordAsync(email, Services.Random.RandomPassword(64));
            await user.User.SendEmailVerificationAsync(GetActionCodeSettings());
            //while (!task.IsComplete) {
            //    // await. Do nothing
            //}
            return true; // return task.isSuccessful
        }
        
        // https://firebase.google.com/docs/auth/android/email-link-auth
        private ActionCodeSettings GetActionCodeSettings() {
            return ActionCodeSettings.NewBuilder()
                // URL you want to redirect back to. The domain (www.example.com) for this
                // URL must be whitelisted in the Firebase Console.
                .SetUrl("www.example.com")
                // This must be true
                .SetHandleCodeInApp(true)
                .SetIOSBundleId("com.LMKCoop.LetMeKnow")
                .SetAndroidPackageName(
                        "com.LMKCoop.LetMeKnow",
                        true,   /* installIfNotAvailable */
                        "12"    /* minimumVersion */)
                .Build();
            //var user = FirebaseAuth.Instance.SendPasswordResetEmail(email, actionCodeSettings);
            //var token = await user.get(false);
            //return token.Token;
        }

        public async void SendPasswordResetEmail(string email) {
            await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
        }
    }
}