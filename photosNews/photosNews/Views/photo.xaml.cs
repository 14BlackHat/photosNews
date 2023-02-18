using photosNews.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace photosNews.Views
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