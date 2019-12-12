using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Tasks;
using Firebase.Auth;

using LetMeKnow.Interfaces;
using Firebase.DynamicLinks;
using Android.Util;

namespace LetMeKnow.Droid.Database {
    public class FirebaseAuthenticator : IFirebaseAuthenticator {
        private readonly FirebaseAuth auth;

        public FirebaseAuthenticator() {
            auth = FirebaseAuth.Instance;
        }

        public async Task<string> LoginWithEmailAndPassword(string email, string password) {
            var user = await auth.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public async Task<EmailState> SendRegisterEmail(string email) {
            try {
                var user = await auth.CreateUserWithEmailAndPasswordAsync(email, Services.Random.RandomPassword(64));
                await user.User.SendEmailVerificationAsync(GetActionCodeSettings());
                //FirebaseAuth.Instance.CurrentUser.Delete(); // delete user, add with password after complete authentication
            } catch (FirebaseAuthInvalidCredentialsException e) {
                return EmailState.BadFormat;
            } catch (FirebaseAuthUserCollisionException e) {
                return EmailState.UserCollision;
            } catch (Exception e) {
                return EmailState.Fail;
            }
            return EmailState.Success;
        }

        public static async Task<string> HandleEmailVerificationLink(Intent intent) {
            var deepLink = intent.Data;
            // parse the deeplink
            if (deepLink != null) {
                if (deepLink.GetQueryParameter("mode") != "verifyEmail") return "NotVerifying";

                var oobCode = deepLink.GetQueryParameter("oobCode");
                try {
                    await FirebaseAuth.Instance.ApplyActionCodeAsync(oobCode);
                    await FirebaseAuth.Instance.CurrentUser.ReloadAsync(); // VERY IMPORTANT!!!!!!!!! RELOAD THE USER!!!!!!!!!!
                    // Verified user. Prompt and ask for username, password.
                    return "Success";
                }
                // If failed to verify, ApplpyActionCodeAsync will throw an exception with the appropriate error code
                catch (FirebaseAuthActionCodeException e) {
                    return e.ErrorCode;
                }
            }

            return "NotVerifying";
        }

        public async void SendPasswordResetEmail(string email) {
            await auth.SendPasswordResetEmailAsync(email);
        }

        public async Task<bool> FinishRegistration(string username, string password) {
            await auth.CurrentUser.UpdateProfileAsync(
                new UserProfileChangeRequest.Builder()
                .SetDisplayName(username)
                .Build());
            await auth.CurrentUser.UpdatePasswordAsync(password);
            await auth.CurrentUser.ReloadAsync();
            return true;
        }

        public string GetDisplayName() {
            if (auth == null) return null;

            return auth.CurrentUser.DisplayName;
        }

        public string GetUid() {
            if (auth == null) return null;

            return auth.CurrentUser.Uid;
        }

        public string GetEmail() {
            if (auth == null) return null;

            return auth.CurrentUser.Email;
        }

        // NOTE: Bad, fake implementation
        public bool IsVerifying() {
            if (auth == null) return false;

            return auth.CurrentUser.IsEmailVerified;
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