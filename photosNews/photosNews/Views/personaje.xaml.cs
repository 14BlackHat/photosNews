using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using photosStarWars.VM;

namespace photosStarWars.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class news : ContentPage
	{
		public news ()
		{
			InitializeComponent ();
            BindingContext = new VMpersonaje(Navigation);
        }
	}
}