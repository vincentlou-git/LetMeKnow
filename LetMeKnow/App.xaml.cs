using Autofac;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.PageLogic;

using Firebase.Database;
using System.Collections.Generic;
using System.Reflection;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LetMeKnow {
    public partial class App : Application {
        public IContainer Container { get; }
        public string AuthToken { get; set; }

        public App(Autofac.Module module) {
            InitializeComponent();

            Container = BuildContainer(module);
            MainPage = new MainPage();
        }

        protected override void OnStart() {
            // Handle when your app starts
            FirebaseClient firebase = new FirebaseClient("https://letmeknow-439fb.firebaseio.com/");
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }

        private IContainer BuildContainer(Autofac.Module module) {
            var builder = new ContainerBuilder();

            // Register every page logic class with assembly scanning
            var asm = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.Namespace == "LetMeKnow.PageLogic");

            builder.RegisterModule(module);
            return builder.Build();
        }
    }
}
