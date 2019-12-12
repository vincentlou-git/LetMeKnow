using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Java.Lang;
using LetMeKnow.Interfaces;
using LetMeKnow.Models;
using LetMeKnow.Services;

namespace LetMeKnow.Droid.Database {
    public class FirebaseDatabaseActor : IFirebaseDatabaseActor {
        private readonly FirebaseDatabase database = FirebaseDatabase.Instance;
        private readonly IFirebaseAuthenticator auth;

        private readonly DatabaseReference userRoot;
        private readonly DatabaseReference userPosts;

        public FirebaseDatabaseActor(IFirebaseAuthenticator auth) {
            this.auth = auth;
            userRoot = database.GetReference("users").Child(auth.GetUid());
            userPosts = database.GetReference("userPosts").Child(auth.GetUid());
        }

        public async Task<bool> CreateCurrentUser() {
            await userRoot.Child("email").SetValueAsync(auth.GetEmail());
            await userRoot.Child("university").SetValueAsync(DomainToUniNameConverter.GetUniversity(auth.GetEmail()));
            await userRoot.Child("userName").SetValueAsync(auth.GetDisplayName());
            await userRoot.Child("pairToken").SetValueAsync(Services.Random.RandomPassword(32));
            await userRoot.Child("lastLogin").OnDisconnect().SetValueAsync(DateTime.Now.Ticks);
            
            return true;
        }

        // Intended for single read
        public async Task<User> ReadCurrUserInfo() {
            var eventListener = new UserValueEventListener();

            userRoot.AddListenerForSingleValueEvent(eventListener);

            return await eventListener.GetUser();
        }

        private class UserValueEventListener : Java.Lang.Object, IValueEventListener {
            public User Data { private set; get; }
            TaskCompletionSource<User> tcs = new TaskCompletionSource<User>();

            public void OnCancelled(DatabaseError error) {
               Log.Warn("FetchUserDBError", error.ToString());
            }

            public void OnDataChange(DataSnapshot snapshot) {
                if (snapshot.Exists()) {
                    Data = SnapshotToUser(snapshot);
                    tcs.SetResult(Data);
                }
            }

            public Task<User> GetUser() {
                return tcs.Task;
            }
        }
        
        // https://forums.xamarin.com/discussion/84732/firebase-database-xamarin-implementation
        private static User SnapshotToUser(DataSnapshot snapshot) {
            User user = new User();

            if (snapshot.GetValue(true) == null) return null; // key, but no value, recently deleted. Return null.

            user.uid = snapshot.Key;
            user.email = snapshot.Child("email")?.GetValue(true)?.ToString();
            user.userName = snapshot.Child("userName")?.GetValue(true)?.ToString();
            user.university = snapshot.Child("university")?.GetValue(true)?.ToString();
            user.pairToken = snapshot.Child("pairToken")?.GetValue(true)?.ToString();
            user.lastLogin = Long.ParseLong(snapshot.Child("lastLogin")?.GetValue(true)?.ToString());
            user.subExpiryDate = Long.ParseLong(snapshot.Child("subExpiryDate")?.GetValue(true)?.ToString());

            return user;
        }

        public async Task<bool> UpdateLastLogin() {
            await userRoot.Child("lastLogin").SetValueAsync(DateTime.Now.Ticks);

            return true;
        }

        public async Task<bool> UpdateLastLoginOnDisconnect() {
            await userRoot.Child("lastLogin").OnDisconnect().SetValueAsync(DateTime.Now.Ticks);

            return true;
        }

        public bool DeleteCurrUserPostAt(DateTime time) {
            return DeleteCurrUserPostAt(time.Ticks);
        }

        public bool DeleteCurrUserPostAt(long ticks) {
            try {
                var post = userPosts.Child(ticks.ToString());
                post.Child("text")?.RemoveValue();
                post.Child("image")?.RemoveValue();
                post.RemoveValue();
            }
            catch (DatabaseException e) {
                Log.Warn("Delete", e.ToString());
                return false;
            }

            return true;
        }
    }
}