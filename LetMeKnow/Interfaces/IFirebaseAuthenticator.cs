using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetMeKnow.Interfaces
{
    // https://stackoverflow.com/questions/49607811/firebase-email-passord-authentication-using-xamarin-forms-with-net-standard-vs
    public interface IFirebaseAuthenticator {
        // Password has to be created later through the reset password link
        void RegisterWithEmail(string email);
        Task<string> LoginWithEmailAndPassword(string email, string password);
    }
}
