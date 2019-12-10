using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using LetMeKnow.Interfaces;

namespace LetMeKnow.iOS.Services {
    public class DatabaseAuthenticator : IFirebaseAuthenticator {
        public async Task<string> LoginWithEmailAndPassword(string email, string password) {
            var user = await Auth.auth().SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public async Task RegisterWithEmail(string email) {
            string password = LetMeKnow.Services.Random.RandomPassword(64);
            FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);
            // TODO: Check what return value this should be from firebase documentation
        }

        public async void SendPasswordResetEmail(string email) {
            await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
        }
    }
}
