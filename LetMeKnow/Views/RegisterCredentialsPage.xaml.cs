using Autofac;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.ViewModels;
using LetMeKnow.Interfaces;
using Autofac.Core;
using System;

namespace LetMeKnow.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCredentialsPage : ContentPage {
        public RegisterCredentialsPage() {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<RegisterCredentialsViewModel>();
        }
    }
}