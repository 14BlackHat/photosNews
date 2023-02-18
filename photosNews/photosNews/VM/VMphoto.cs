using photosNews.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace photosNews.VM
{
    public class VMphoto : BaseViewModel
    {
        #region VARIABLES
        private string _usuario;
        #endregion
        #region CONSTRUCTOR
        public VMphoto(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string usuario
        {
            get { return _usuario; }
            set { SetValue(ref _usuario, value); }
        }
        #endregion
        #region PROCESOS
        public async Task photoClicked()
        {
            await Navigation.PushAsync(new photo());
        }
        public async Task salirClicked()
        {
            await Navigation.PopToRootAsync();
        }
        public async Task newsClicked()
        {
            await Navigation.PushAsync(new news());
        }
        public async Task takePhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Directory = "Photos & News",
                Name = "test.jpg"
            });

            if (file == null)
                return;
        }
        #endregion
        #region COMANDOS
        public ICommand photoCommand => new Command(async () => await photoClicked());
        public ICommand salirCommand => new Command(async () => await salirClicked());
        public ICommand newsCommand => new Command(async () => await newsClicked());
        public ICommand takePhotoCommand => new Command(async () => await takePhoto());
        public INavigation Navigation { get; }
        #endregion
    }
}
