using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using LetMeKnow.Interfaces;
using LetMeKnow.Models;
using LetMeKnow.Services;

namespace LetMeKnow.Droid.Database {
    public class FirebaseDatabaseActor : IFirebaseDatabaseActor {
        private readonly FirebaseDatabase database = FirebaseDatabase.Instance;
        private readonly IFirebaseAuthenticator auth;

        private readonly DatabaseReference userRoot;

        public FirebaseDatabaseActor(IFirebaseAuthenticator auth) {
            this.auth = auth;
            userRoot = database.GetReference("users").Child(auth.GetUid());
        }

        public async Task<bool> CreateCurrentUser() {
            await userRoot.Child("email").SetValueAsync(auth.GetEmail());
            await userRoot.Child("university").SetValueAsync(DomainToUniNameConverter.GetUniversity(auth.GetEmail()));
            await userRoot.Child("userName").SetValueAsync(auth.GetDisplayName());
            await userRoot.Child("pairToken").SetValueAsync(Services.Random.RandomPassword(32));
            await userRoot.Child("lastLogin").SetValueAsync(DateTime.Now.Ticks);

            return true;
        }

        public async Task<User> ReadCurrUser() {
            throw new NotImplementedException();
            userRoot.AddValueEventListener(new ValueEventListener());
        }

        private class ValueEventListener : Java.Lang.Object, IValueEventListener {
            public void OnCancelled(DatabaseError error) {
                throw new NotImplementedException();
            }

            public void OnDataChange(DataSnapshot snapshot) {
                if (snapshot.Exists()) {
                    User user = new User();
                    var obj = snapshot.Children;
                }
            }
        }

        public async Task<bool> UpdateLastLogin() {
            await userRoot.Child("lastLogin").SetValueAsync(DateTime.Now.Ticks);

            return true;
        }

        public async Task<bool> DeleteCurrUserPostAt(DateTime time) {
            throw new NotImplementedException();
        }
    }
}