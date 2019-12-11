using System;
using System.Collections.Generic;
using System.Text;

using LetMeKnow.Services;
using LetMeKnow.Interfaces;

namespace LetMeKnow.ViewModels
{
    public class HomePageViewModel : ViewModel {
        public string UserName { protected set; get; }
        public string University { protected set; get; }
        public DateTime CourseBeginDate { protected set; get; }
        public DateTime GradDate { protected set; get; }

        private readonly FirebaseDatabaseService fds;
        private readonly IFirebaseAuthenticator auth;

        public HomePageViewModel(FirebaseDatabaseService fds, IFirebaseAuthenticator auth) {
            this.fds = fds;
            this.auth = auth;

            UserName = auth.GetDisplayName();
            //University = fds.
            //CourseBeginDate = 
            //GradDate = 

            fds.CreateCurrentUser();
        }


    }
}
