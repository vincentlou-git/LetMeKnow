using System;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.ViewModels {
    class GenericPopupViewModel : ViewModel {
        public string Message { get; } // Text that describes what happened

        public GenericPopupViewModel(string message) {
            Message = message;
        }
    }
}
