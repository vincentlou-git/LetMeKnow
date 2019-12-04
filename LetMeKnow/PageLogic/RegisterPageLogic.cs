using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LetMeKnow.Interfaces;

namespace LetMeKnow.PageLogic
{
    public class RegisterPageLogic : PageLogic
    {
        public string Email { get; }
        public string Password { get; }

        readonly IFirebaseAuthenticator firebaseAuth;
        
        public RegisterPageLogic(IFirebaseAuthenticator firebaseAuth) {
            this.firebaseAuth = firebaseAuth;
        }

        public void Register() {
            IsBusy = true;

            firebaseAuth.RegisterWithEmail(Email);

            IsBusy = false;
        }
    }
}
