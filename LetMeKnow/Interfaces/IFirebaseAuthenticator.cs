using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetMeKnow.Interfaces
{
    // https://stackoverflow.com/questions/49607811/firebase-email-passord-authentication-using-xamarin-forms-with-net-standard-vs
    public interface IFirebaseAuthenticator {
        /** 
         * Register:
         * Enter email, createUserWithEmailAndPassword to firebase
         * Send email for password reset
         */
        Task<bool> RegisterWithEmail(string email);
        void SendPasswordResetEmail(string email);
        Task<string> LoginWithEmailAndPassword(string email, string password);
    }
}
