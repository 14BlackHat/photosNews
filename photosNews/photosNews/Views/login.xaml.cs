using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using photosStarWars.VM;

namespace photosStarWars.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class login : ContentPage
	{
		public login()
		{
			InitializeComponent();
			BindingContext = new VMlogin(Navigation);
		}
    }
}