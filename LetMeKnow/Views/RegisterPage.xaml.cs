using Autofac;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.ViewModels;

namespace LetMeKnow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage {
        public RegisterPage() {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<RegisterViewModel>();
        }

        //private async void button_Clicked(object sender, EventArgs e) {
            
        //    // This is "fake". At this point we have already "authenticated" the email with a random password.
        //    // What we have sent is a password reset email.
        //    await DisplayAlert("Check you mailbox!", "We have sent a link for email verification to " + emailField.Text + ".", "Got it!");

        //    //    await DisplayAlert("Failed", "We couldn't send you the code. Sorry.", "Got it!");

        //}
    }
}