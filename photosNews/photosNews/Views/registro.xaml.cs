using photosNews.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace photosNews.Views
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