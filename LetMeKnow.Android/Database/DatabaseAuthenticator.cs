using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;

using LetMeKnow.Interfaces;
using LetMeKnow.Services;

namespace LetMeKnow.Droid.Database {
    public class DatabaseAuthenticator : IFirebaseAuthenticator {
        public async Task<string> LoginWithEmailAndPassword(string email, string password) {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public void RegisterWithEmail(string email) {
            string password = LetMeKnow.Services.Random.RandomPassword(64);
            FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);
            // TODO: Check what return value this should be from firebase documentation
        }
    }
}