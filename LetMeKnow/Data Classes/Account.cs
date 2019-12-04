using System;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.Data_Classes
{
    class Account {
        public string Email { get; set; }
        public bool IsVerified { get; set; }
    }

    class UnverifiedAccount : Account {

    }

    class VerifiedAccount : Account {
        public string Username { get; set; }
        // public Image? ProfileImage {get; set;}
        public string PairCode { get; set; }
    }
}
