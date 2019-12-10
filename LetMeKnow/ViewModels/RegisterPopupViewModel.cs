using System;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.ViewModels {
    class RegisterPopupViewModel : ViewModel {
        public string Message { get; } // Text that describes what happened

        public RegisterPopupViewModel(bool isSuccessful, string email) {
            Message = "An error occurred. Please try again later.";
            // how to get binding (SendSuccess) from another View Model?
            if (isSuccessful) {
                Message = "We have sent an email to " + email + ".";
            }
            else {
                Message = "Failed to send an email to " + email + ".\nPlease try again later.";
            }
        }
    }
}
