using System;
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

        public async Task<RegisterState> RegisterWithEmail(string email) {
            try {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, Services.Random.RandomPassword(64));
                await user.User.SendEmailVerificationAsync(GetActionCodeSettings());
            } catch (FirebaseAuthInvalidCredentialsException e) {
                return RegisterState.BadFormat;
            } catch (FirebaseAuthUserCollisionException e) {
                return RegisterState.UserCollision;
            } catch (Exception e) {
                return RegisterState.Fail;
            }
            return RegisterState.Success;
        }
        
        // https://firebase.google.com/docs/auth/android/email-link-auth
        private ActionCodeSettings GetActionCodeSettings() {
            return ActionCodeSettings.NewBuilder()
                // URL you want to redirect back to. The domain (www.example.com) for this
                // URL must be whitelisted in the Firebase Console.
                .SetUrl("https://letmeknow.page.link/Verify")
                // This must be true
                .SetHandleCodeInApp(true)
                .SetIOSBundleId("com.LMKCoop.LetMeKnow")
                .SetAndroidPackageName(
                        "com.LMKCoop.LetMeKnow",
                        true,   /* installIfNotAvailable */
                        "1"    /* minimumVersion */)
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