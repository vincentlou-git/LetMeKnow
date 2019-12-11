using Firebase.Database;
using Firebase.Database.Query;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using LetMeKnow.Models;
using LetMeKnow.Interfaces;

namespace LetMeKnow.Services {
    // Implements CRUD Operations
    public class FirebaseDatabaseService {
        private readonly FirebaseClient firebase = new FirebaseClient("https://letmeknow-439fb.firebaseio.com/");

        private readonly IFirebaseAuthenticator firebaseAuth;

        public FirebaseDatabaseService(IFirebaseAuthenticator firebaseAuth) {
            this.firebaseAuth = firebaseAuth;
        }

        // --------------- Create ---------------
        public async Task CreateCurrentUser() {
            // Create username
            await firebase
                .Child("users")
                .PostAsync(new User() { UserName=firebaseAuth.GetDisplayName() });

            //// Create uid
            //await firebase
            //    .Child(firebaseAuth.GetUid())
            //    .PostAsync(new User() { PairToken= Random.RandomPassword(32), LastLogin=Timestamp});
        }

        public async Task UpdateLastLogin() {

        }

        public async Task CreatePost(Post post) {

        }

        // --------------- Read ---------------
        // Equivalent to Search.
        // Any user is allowed to search for usernames
        //public async Task<List<User>> ReadAllUsers() {

        //}
        
        //public async Task<User> ReadCurrUser() {
        //    //firebaseAuth.GetUid();
        //}
        
        //public async Task<List<Post>> ReadAllPostsFromCurrUser() {

        //}

        //public async Task<Post> ReadPostByDate(DateTime date) {
        //    // convert date to timestamp, compare against all posts by curr user
        //}

        // --------------- Update ---------------
        public async Task UpdateUser(User user) {

        }

        public async Task UpdatePost(Post post) {

        }

        // --------------- Delete ---------------
        public async Task DeleteCurrUser() {

        }

        public async Task DeletePost(DateTime time) {

        }
    }
}
