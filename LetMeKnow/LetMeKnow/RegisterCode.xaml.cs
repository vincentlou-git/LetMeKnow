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

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            button.IsEnabled = email.Text != "";
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Check you mailbox!", "We have sent an confirmation email to " + email.Text + ".", "Got it!");
        }
    }
}