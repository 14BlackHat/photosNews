using photosNews.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using photosNews.Models;
using System.Collections.ObjectModel;
using static Xamarin.Essentials.Permissions;
using Xamarin.Essentials;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace photosNews.VM
{
    public class VMnews : BaseViewModel
    {
        #region VARIABLES
        public ObservableCollection<articulo> articulosOC;
        private string _titulo;
        private string _autor;
        private string _descripcion;
        private string _url;
        private string _publicacion;
        private int _articulos;
        #endregion
        #region CONSTRUCTOR
        public VMnews(INavigation navigation)
        {
            Navigation = navigation;
            noticias();
        }
        #endregion
        #region OBJETOS

        public ObservableCollection<articulo> articulosModel
        {
            get { return articulosOC; }
            set { SetValue(ref articulosOC, value); }
        }
        public string titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }
        public string autor
        {
            get { return _autor; }
            set { SetValue(ref _autor, value); }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { SetValue(ref _descripcion, value); }
        }
        public string url
        {
            get { return _url; }
            set { SetValue(ref _url, value); }
        }
        public string publicacion
        {
            get { return _publicacion; }
            set { SetValue(ref _publicacion, value); }
        }
        public int articulos
        {
            get { return _articulos; }
            set { SetValue(ref _articulos, value); }
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
        public async void noticias()
        {
            try
            {
                articulosOC = new ObservableCollection<articulo>();
                var url = "https://newsapi.org/v2/top-headlines?country=us&apiKey=f9ac29898e5a409ab3aa8208c0c78e8e";
                var json = new WebClient().DownloadString(url);

                var jsonObject = JObject.Parse(json);

                var status = jsonObject["status"];
                var total = jsonObject["totalResults"];
                var data = jsonObject["articles"];
                var jsonArray = JArray.Parse(data.ToString());
  
                foreach (var token in jsonArray)
                {
                    articulo articuloAux = new articulo();
                    articuloAux.author = token["author"].ToString();
                    articuloAux.title = token["title"].ToString();
                    articuloAux.url = token["url"].ToString();
                    articuloAux.urlToImage = token["urlToImage"].ToString();

                    articulosOC.Add(articuloAux);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error de Peticiòn", ex.Message, "Aceptar");
                await Navigation.PopAsync();
            }                       
        }
        #endregion
        #region COMANDOS
        public ICommand photoCommand => new Command(async () => await photoClicked());
        public ICommand salirCommand => new Command(async () => await salirClicked());
        public ICommand newsCommand => new Command(async () => await newsClicked());
        public INavigation Navigation { get; }
        #endregion
    }
}
