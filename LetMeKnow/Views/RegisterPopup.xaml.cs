using Autofac;
using Autofac.Core;
using LetMeKnow.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.Interfaces;

namespace LetMeKnow.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPopup : Rg.Plugins.Popup.Pages.PopupPage {

        public RegisterPopup(EmailState registerState, string email) {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<RegisterPopupViewModel>(
                new TypedParameter(typeof(EmailState), registerState),
                new TypedParameter(typeof(string), email));
        }

        private async void OnClose(object sender, EventArgs e) {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}