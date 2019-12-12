using System;
using System.Collections.Generic;
using System.Text;

using LetMeKnow.Services;
using LetMeKnow.Interfaces;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LetMeKnow.ViewModels
{
    public class HomePageViewModel : ViewModel {
        string userName;
        public string UserName {
            get => userName;
            set {
                if (value != userName) {
                    userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        string university;
        public string University {
            get => university;
            set {
                if (value != university) {
                    university = value;
                    OnPropertyChanged("University");
                }
            }
        }

        DateTime courseBeginDate;
        public DateTime CourseBeginDate {
            get => courseBeginDate;
            set {
                if (value != courseBeginDate) {
                    courseBeginDate = value;
                    OnPropertyChanged("CourseBeginDate");
                }
            }
        }

        DateTime courseEndDate;
        public DateTime CourseEndDate {
            get => courseEndDate;
            set {
                if (value != courseEndDate) {
                    courseEndDate = value;
                    OnPropertyChanged("CourseEndDate");
                }
            }
        }

        public ICommand DeletePostCmd { protected set; get; }

        private readonly IFirebaseDatabaseActor database;
        private readonly IFirebaseAuthenticator auth;

        public HomePageViewModel(IFirebaseDatabaseActor database, IFirebaseAuthenticator auth) {
            this.database = database;
            this.auth = auth;
            
            UserName = auth.GetDisplayName();

            DeletePostCmd = new Command(async () => {
                // Execute
                bool success = database.DeleteCurrUserPostAt(637117713349292756);
                Console.WriteLine("Delete success? " + success);
            });

            database.UpdateLastLoginOnDisconnect();
        }



        public async Task BeforeAppearing() {
            University = (await database.ReadCurrUserInfo()).university;
            // TODO: set course times
            //Console.WriteLine("Info at userRoot: " + University);
        }
    }
}
