using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using LetMeKnow.Interfaces;

using Xamarin.Forms;

namespace LetMeKnow.ViewModels
{
    public class RegisterViewModel : ViewModel {

        public ICommand RegisterCmd { protected set; get; }
        //Action propChangedCallBack => (RegisterCmd as Command).ChangeCanExecute;

        readonly IFirebaseAuthenticator firebaseAuth;
        
        public RegisterViewModel(IFirebaseAuthenticator firebaseAuth) {
            this.firebaseAuth = firebaseAuth;
            RegisterCmd = new Command(() => {
                // Execute
                Register();
            }, 
            () => {
                // CanExecute - yes if email is not empty
                return IsClickable;
            });
        }

        // ------------- Public properties -------------

        // Note: This is explicitly handled because boilerplate code can't satisfy the chain reaction that causes other properties to update
        // ^^^^ that is not true, just create a property that depend on Email
        private string email = "";
        public bool IsClickable { protected set; get; }
        public string Email {
            // not protected
            set {
                if (email != value) {
                    email = value;
                    OnPropertyChanged("Email");

                    // Enable click
                    IsClickable = email.Length > 0;
                    ((Command)RegisterCmd).ChangeCanExecute();
                }
            }

            get { return email; }
        }

        private void Register() {
            //IsBusy = true;
            //propChangedCallBack();

            firebaseAuth.RegisterWithEmail(Email);
            //(Application.Current as App).AuthToken = 
            firebaseAuth.SendPasswordResetEmail(Email);

            //IsBusy = false;
            //propChangedCallBack();
        }
    }
}
