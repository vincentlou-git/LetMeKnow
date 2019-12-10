using System;
using System.Collections.Generic;
using System.Text;

using LetMeKnow.Interfaces;

namespace LetMeKnow.ViewModels {
    class RegisterPopupViewModel : ViewModel {
        public string Message { get; } // Text that describes what happened

        public RegisterPopupViewModel(RegisterState registerState, string email) {

            switch (registerState) {
                case RegisterState.Success:
                    Message = "We have sent an email to " + email + ".\n\n Please verify your email by clicking the link in the email.";
                    break;

                case RegisterState.BadFormat:
                    Message = "Failed to send an email to " + email + ".\n\nReason: The email format is invalid.";
                    break;

                case RegisterState.UserCollision:
                    Message = email + " already has an email sent to!\n\nPlease check your junk mails.";
                    break;

                case RegisterState.Fail:
                    Message = "Failed to send an email to " + email + ".\n\nPlease try again later.";
                    break;

                default:
                    Message = "An error occurred. Please try again later.";
                    break;
            }
        }
    }
}
