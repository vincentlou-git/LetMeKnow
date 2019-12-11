using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Essentials;

using LetMeKnow.Interfaces;

namespace LetMeKnow.ViewModels {
    class RegisterPopupViewModel : ViewModel {
        public string Message { get; } // Text that describes what happened

        public RegisterPopupViewModel(EmailState registerState, string email) {

            switch (registerState) {
                case EmailState.Success:
                    Message = "We have sent an email to " + email + ".\n\nWithout closing this session, verify your email by clicking the link in the email.";
                    
                    Preferences.Set("email", email); // save email locally
                    break;

                case EmailState.BadFormat:
                    Message = "Failed to send an email to " + email + ".\n\nReason: The email format is invalid.";
                    break;

                case EmailState.UserCollision:
                    Message = email + " already has an email sent to!\n\nPlease check your junk mails.";
                    break;

                case EmailState.Fail:
                    Message = "Failed to send an email to " + email + ".\n\nPlease try again later.";
                    break;

                default:
                    Message = "An error occurred. Please try again later.";
                    break;
            }
        }
    }
}
