using System;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.Models
{
    public class User {
        public string Uid { get; set; }
        public string UserName { get; set; }
        public bool IsVerified { get; }
        public string PairToken { get; set; }
        public int LastLogin { get; set; }
        public int SubExpiryDate { get; set; }
    }
}
