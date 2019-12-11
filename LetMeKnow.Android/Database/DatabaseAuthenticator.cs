using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Tasks;
using Firebase.Auth;

using LetMeKnow.Interfaces;
using Firebase.DynamicLinks;
using Android.Util;

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

        public static async Task<bool> HandleEmailVerificationLink(Intent intent) {
            var deepLink = intent.Data;
            // parse the deeplink
            if (deepLink != null) {
                if (deepLink.GetQueryParameter("mode") != "verifyEmail") return false;

                var oobCode = deepLink.GetQueryParameter("oobCode");
                //oobCode = "1234567890";
                try {
                    await FirebaseAuth.Instance.ApplyActionCodeAsync(oobCode);
                    await FirebaseAuth.Instance.CurrentUser.ReloadAsync();
                    Log.Debug("email verification:", FirebaseAuth.Instance.CurrentUser.IsEmailVerified.ToString());
                    return true;
                }
                catch (FirebaseAuthActionCodeException e) {
                    if (e.ErrorCode == "ERROR_INVALID_ACTION_CODE") {
                        Log.Debug("email veri", "invalid action code");
                    } else if (e.ErrorCode == "ERROR_INVALID_ACTION_CODE") {
                        Log.Debug("email veri", e.ErrorCode);
                    } else if (e.ErrorCode == "ERROR_USER_DISABLED") {

                    } else if (e.ErrorCode == "ERROR_ACCOUNT_EXISTS_WITH_DIFFERENT_CREDENTIAL") {

                    } else if (e.ErrorCode == "ERROR_OPERATION_NOT_ALLOWED") {

                    } else {

                    }
                }
            }

            return false;
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