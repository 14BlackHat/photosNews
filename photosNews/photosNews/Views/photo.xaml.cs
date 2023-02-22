using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using photosStarWars.VM;

namespace photosStarWars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class photo : ContentPage
	{
        public photo()
        {
            InitializeComponent();
            BindingContext = new VMphoto(Navigation);
        }
    }
}