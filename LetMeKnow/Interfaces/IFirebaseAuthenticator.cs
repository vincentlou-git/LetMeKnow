using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LetMeKnow.ViewModels;

namespace LetMeKnow.Interfaces {
    public enum EmailState { Success, UserCollision, BadFormat, NoUser, Fail }

    // https://stackoverflow.com/questions/49607811/firebase-email-passord-authentication-using-xamarin-forms-with-net-standard-vs
    public interface IFirebaseAuthenticator {
        /** 
         * Register:
         * Enter email, createUserWithEmailAndPassword to firebase
         * Send email for verification
         */
        // Catch all the errors in this function, return the appropriate EmailState
        Task<EmailState> RegisterWithEmail(string email);
        //void HandleEmailVerificationLink(string emailLink);
        void SendPasswordResetEmail(string email);
        Task<string> LoginWithEmailAndPassword(string email, string password);
        
    }
}
