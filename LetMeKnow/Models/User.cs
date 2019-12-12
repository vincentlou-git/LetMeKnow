using System;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.Models
{
    public class User {
        public string email { get; set; }
        public string userName { get; set; }
        public string university { get; set; }
        public string pairToken { get; set; }
        public long lastLogin { get; set; }
        public long subExpiryDate { get; set; }
    }
}
