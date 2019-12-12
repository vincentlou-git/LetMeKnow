using System.Windows.Input;

using Rg.Plugins.Popup.Services;

using LetMeKnow.Interfaces;

using Xamarin.Forms;
using System;
using System.ComponentModel;

namespace LetMeKnow.ViewModels
{
    public class RegisterViewModel : ViewModel {

        public ICommand RegisterCmd { protected set; get; }
        //Action propChangedCallBack => (RegisterCmd as Command).ChangeCanExecute;

        readonly IFirebaseAuthenticator firebaseAuth;

        public event PropertyChangedEventHandler PropertyChanged;

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

        private async void Register() {
            //IsBusy = true;
            //propChangedCallBack();

            EmailState rState = await firebaseAuth.SendRegisterEmail(Email);
            await PopupNavigation.Instance.PushAsync(new Views.RegisterPopup(rState, Email));

            //IsBusy = false;
            //propChangedCallBack();
        }

        protected void OnPropertyChanged(string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
