﻿using Autofac;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LetMeKnow.PageLogic;

namespace LetMeKnow.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PairPage : ContentPage
	{
		public PairPage ()
		{
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<PairPageLogic>();
        }
    }
}