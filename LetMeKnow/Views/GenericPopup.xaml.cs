using Autofac;
using Autofac.Core;
using LetMeKnow.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetMeKnow.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenericPopup : Rg.Plugins.Popup.Pages.PopupPage {

        public string Message { get; }

        public GenericPopup(string message) {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<GenericPopupViewModel>(
                new TypedParameter(typeof(string), message));
        }

        private async void OnClose(object sender, EventArgs e) {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}