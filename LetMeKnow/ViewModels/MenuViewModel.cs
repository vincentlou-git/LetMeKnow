using System.Windows.Input;

using Rg.Plugins.Popup.Services;

using LetMeKnow.Interfaces;

using Xamarin.Forms;
using System;

using LetMeKnow.Views;

namespace LetMeKnow.ViewModels {
    public class MenuViewModel : ViewModel {

        public ICommand RegisterCmd { protected set; get; }
        public ICommand LoginCmd { protected set; get; }
        public ICommand PairCmd { protected set; get; }
        //Action propChangedCallBack => (RegisterCmd as Command).ChangeCanExecute;

        public MenuViewModel() {
            RegisterCmd = new Command(async () => {
                await (Application.Current as App).MainPage.Navigation.PushAsync(new RegisterPage());
            });
            LoginCmd = new Command(async () => {
                await (Application.Current as App).MainPage.Navigation.PushAsync(new LoginPage());
            });
            PairCmd = new Command(async () => {
                await (Application.Current as App).MainPage.Navigation.PushAsync(new PairPage());
            });
        }
    }
}
