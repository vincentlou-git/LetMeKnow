using Autofac;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.ViewModels;

namespace LetMeKnow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage {
        public RegisterPage() {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<RegisterViewModel>();
        }
    }
}