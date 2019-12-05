using Autofac;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.PageLogic;

namespace LetMeKnow {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage {
        public RegisterPage() {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<RegisterPageLogic>();
        }

        private void emailField_TextChanged(object sender, TextChangedEventArgs e) {
            button.IsEnabled = emailField.Text != "";
        }

        private async void button_Clicked(object sender, EventArgs e) {
            
            await DisplayAlert("Check you mailbox!", "We have sent a link for you to set the password to " + emailField.Text + ".", "Got it!");
            
            //    await DisplayAlert("Failed", "We couldn't send you the code. Sorry.", "Got it!");
            
        }
    }
}