using Autofac;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.ViewModels;

namespace LetMeKnow.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage {
        public MenuPage() {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<MenuViewModel>();
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