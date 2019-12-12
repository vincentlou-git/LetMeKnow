using Java.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.Models
{
    public class User {
        public string uid { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string university { get; set; }
        public string pairToken { get; set; }
        public long lastLogin { get; set; }
        public long subExpiryDate { get; set; }

        // Serialization
        public HashMap ToMap() {
            return UserToHashMap(this);
        }

        public static HashMap KeylessUserToHashMap(User user) {
            HashMap map = new HashMap();
            // Could use reflection, but it's slow
            map.Put("email", user.email);
            map.Put("userName", user.userName);
            map.Put("university", user.university);
            map.Put("pairToken", user.pairToken);
            map.Put("lastLogin", user.lastLogin);
            map.Put("subExpiryDate", user.subExpiryDate);

            return map;
        }

        public static HashMap UserToHashMap(User user) {
            HashMap map = KeylessUserToHashMap(user);
            map.Put("uid", user.uid);
            return map;
        }
    }
}
