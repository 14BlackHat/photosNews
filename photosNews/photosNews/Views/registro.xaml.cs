﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using photosStarWars.VM;

namespace photosStarWars.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class registro : ContentPage
	{
		public registro ()
		{
			InitializeComponent ();
            BindingContext = new VMregistro(Navigation);
        }
	}
}