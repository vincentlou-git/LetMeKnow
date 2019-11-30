using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetMeKnow
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterCode : ContentPage
	{
		public RegisterCode ()
		{
			InitializeComponent ();
		}

        private void emailField_TextChanged(object sender, TextChangedEventArgs e)
        {
            button.IsEnabled = emailField.Text != "";
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            if (true) {
                await DisplayAlert("Check you mailbox!", "We have sent a verification code to " + emailField.Text + ".", "Got it!");
            }
            else {
                await DisplayAlert("Failed", "We couldn't send you the code. Sorry.", "Got it!");
            }
        }
    }
}