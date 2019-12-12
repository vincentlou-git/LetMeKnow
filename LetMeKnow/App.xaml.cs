using Autofac;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.Generic;
using System.Reflection;
using System;

using LetMeKnow.Services;
using LetMeKnow.Views;
using LetMeKnow.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LetMeKnow {
    public partial class App : Application {
        public IContainer Container { get; }
        public string AuthToken { get; set; }

        public App(Autofac.Module module, string isVerifying) {
            InitializeComponent();

            Container = BuildContainer(module);
            if (isVerifying == "Success") {
                MainPage = new NavigationPage(new RegisterCredentialsPage());
            }
            else {
                MainPage = new NavigationPage(new MenuPage());
            }
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }

        private IContainer BuildContainer(Autofac.Module module) {
            var builder = new ContainerBuilder();

            // Register every ViewModel class with assembly scanning
            var asm = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.Namespace == "LetMeKnow.ViewModels");

            builder.RegisterModule(module);
            return builder.Build();
        }
    }
}
