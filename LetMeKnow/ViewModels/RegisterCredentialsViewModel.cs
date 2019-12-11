using System.Windows.Input;

using Rg.Plugins.Popup.Services;

using LetMeKnow.Interfaces;

using Xamarin.Forms;
using System;
using LetMeKnow.Views;

namespace LetMeKnow.ViewModels {
    public class RegisterCredentialsViewModel : ViewModel {

        public ICommand FinishCmd { protected set; get; }
        public string Email { get; }

        readonly IFirebaseAuthenticator firebaseAuth;

        public RegisterCredentialsViewModel(IFirebaseAuthenticator firebaseAuth) {
            Email = firebaseAuth.GetEmail();
            this.firebaseAuth = firebaseAuth;
            FinishCmd = new Command(() => {
                // Execute
                FinRegister();
            },
            () => {
                // CanExecute
                return IsClickable;
            });
        }

        public bool IsClickable { protected set; get; }
        private string username = "";
        public string UserName {
            // not protected
            set {
                if (username != value) {
                    username = value;
                    OnPropertyChanged("UserName");

                    // Enable click
                    IsClickable = UserName.Length > 4 && Password.Length >= 6;
                    ((Command)FinishCmd).ChangeCanExecute();
                }
            }

            get { return username; }
        }
        private string password = "";
        public string Password {
            // not protected
            set {
                if (password != value) {
                    password = value;
                    OnPropertyChanged("Password");

                    // Enable click
                    IsClickable = UserName.Length > 4 && Password.Length >= 6;
                    ((Command)FinishCmd).ChangeCanExecute();
                }
            }

            get { return password; }
        }

        private async void FinRegister() {
            firebaseAuth.FinishRegistration(UserName, Password);
            await PopupNavigation.Instance.PushAsync(new GenericPopup("You finished registration!\nRedirecting to your homepage..."));
            // TODO: push HOME page
            await (Application.Current as App).MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
