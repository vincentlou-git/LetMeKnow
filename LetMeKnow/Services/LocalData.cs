using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Essentials;

namespace LetMeKnow.Services
{
    public class LocalData {
        public static string Email { get { return Preferences.Get("email", "NONE"); } }
    }
}
