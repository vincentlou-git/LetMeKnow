using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Firebase.Auth;

using LetMeKnow.Interfaces;
using Xamarin.Forms;

namespace LetMeKnow.Droid.Database {
    public class DatabaseAuthenticator : IFirebaseAuthenticator {

        public async Task<string> LoginWithEmailAndPassword(string email, string password) {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public async Task RegisterWithEmail(string email) {
            //string password = LetMeKnow.Services.Random.RandomPassword(64);
            //FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);
            // TODO: Check what return value this should be from firebase documentation

            await FirebaseAuth.Instance.CurrentUser.SendEmailVerificationAsync(GetActionCodeSettings());
        }
        
        // https://firebase.google.com/docs/auth/android/email-link-auth
        private ActionCodeSettings GetActionCodeSettings() {
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
        }

        public async void SendPasswordResetEmail(string email) {
            await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
        }
    }
}