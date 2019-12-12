using Autofac;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.ViewModels;

using System;

namespace LetMeKnow.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            this.BindingContext = (Application.Current as App).Container.Resolve<HomePageViewModel>();
		}

        protected override async void OnAppearing() {
            await (Application.Current as App).Container.Resolve<HomePageViewModel>().BeforeAppearing();
            base.OnAppearing();
        }
    }
}