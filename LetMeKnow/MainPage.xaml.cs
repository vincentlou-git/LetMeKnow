using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.Views;

namespace LetMeKnow {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            //this.BindingContext = (Application.Current as App).Container.Resolve<MainPageLogic>();
        }

        private void register_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new RegisterPage());
        }

        private void login_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new LoginPage());
        }

        private void pair_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new PairPage());
        }
    }
}