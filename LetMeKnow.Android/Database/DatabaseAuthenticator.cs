using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Tasks;
using Firebase.Auth;

using LetMeKnow.Interfaces;
using Firebase.DynamicLinks;

namespace LetMeKnow.Droid.Database {
    public class DatabaseAuthenticator : IFirebaseAuthenticator {

        public async Task<string> LoginWithEmailAndPassword(string email, string password) {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public async Task<EmailState> RegisterWithEmail(string email) {
            try {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, Services.Random.RandomPassword(64));
                await user.User.SendEmailVerificationAsync(GetActionCodeSettings());

            } catch (FirebaseAuthInvalidCredentialsException e) {
                return EmailState.BadFormat;
            } catch (FirebaseAuthUserCollisionException e) {
                return EmailState.UserCollision;
            } catch (Exception e) {
                return EmailState.Fail;
            }
            return EmailState.Success;
        }

        public static void HandleEmailVerificationLink(Intent intent) {
            string deepLink = intent.ToString();
            Console.WriteLine(deepLink);
        }

        public async void SendPasswordResetEmail(string email) {
            await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
        }

        // https://firebase.google.com/docs/auth/android/email-link-auth
        private ActionCodeSettings GetActionCodeSettings() {
            return ActionCodeSettings.NewBuilder()
                // URL you want to redirect back to.
                .SetUrl("https://letmeknow.page.link/Help")
                .SetHandleCodeInApp(true)
                .SetIOSBundleId("com.LMKCoop.LetMeKnow")
                .SetAndroidPackageName(
                        "com.LMKCoop.LetMeKnow",
                        true,   /* installIfNotAvailable */
                        "1"    /* minimumVersion */)
                .Build();
        }
    }
}