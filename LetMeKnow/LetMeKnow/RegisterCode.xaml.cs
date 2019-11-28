using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

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
            await SendEmail("LetMeKnow Registration",
                            "Hi,\n\nClick the link below to activate your LetMeKnow account!\n\nLINK",
                            new List<string> { email.Text } );
            await DisplayAlert("Check you mailbox!", "We have sent an confirmation email to " + email.Text + ".", "Got it!");
        }

        // ------- <Ref> Taken from https://docs.microsoft.com/en-us/xamarin/essentials/email?tabs=android --------
        private async Task SendEmail(string subject, string body, List<string> recipients) {
            try {
                var message = new EmailMessage {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx) {
                // Email is not supported on this device
            }
            catch (Exception ex) {
                // Some other exception occurred
            }
        }
        // ---------- </Ref> Taken -----------
    }
}