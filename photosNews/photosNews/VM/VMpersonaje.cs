using photosStarWars.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Security;
using photosStarWars.Models;

namespace photosStarWars.VM
{
    public class VMpersonaje : BaseViewModel
    {
        #region VARIABLES
        public ObservableCollection<personaje> personajesOC;
        private string _name;
        private string _height;
        private string _mass;
        private string _skin_color;
        private string _birth_year;
        private string _gender;
        #endregion
        #region CONSTRUCTOR
        public VMpersonaje(INavigation navigation)
        {
            Navigation = navigation;
            noticias();
        }
        #endregion
        #region OBJETOS

        public ObservableCollection<personaje> personajesModel
        {
            get { return personajesOC; }
            set { SetValue(ref personajesOC, value); }
        }
        public string name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }
        public string height
        {
            get { return _height; }
            set { SetValue(ref _height, value); }
        }
        public string mass
        {
            get { return _mass; }
            set { SetValue(ref _mass, value); }
        }
        public string skin_color
        {
            get { return _skin_color; }
            set { SetValue(ref _skin_color, value); }
        }
        public string birth_year
        {
            get { return _birth_year; }
            set { SetValue(ref _birth_year, value); }
        }
        public string gender
        {
            get { return _gender; }
            set { SetValue(ref _gender, value); }
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
                personajesOC = new ObservableCollection<personaje>();
                var url = "https://swapi.dev/api/people/?format=json";
                var json = new WebClient();

                ServicePointManager.ServerCertificateValidationCallback = new
                RemoteCertificateValidationCallback
                (
                    delegate { return true; }
                );

                var content = json.DownloadString(url);

                var jsonObject = JObject.Parse(content);

                var count = jsonObject["count"];
                var next = jsonObject["next"];
                var previous = jsonObject["previous"];
                var results = jsonObject["results"];
                var jsonArray = JArray.Parse(results.ToString());

                foreach (var token in jsonArray)
                {
                    personaje personajeAux = new personaje();
                    personajeAux.name = token["name"].ToString();
                    personajeAux.height = token["height"].ToString();
                    personajeAux.mass = token["mass"].ToString();
                    personajeAux.skin_color = token["skin_color"].ToString();
                    personajeAux.birth_year = token["birth_year"].ToString();
                    personajeAux.gender = token["gender"].ToString();

                    personajesOC.Add(personajeAux);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error de Peticiòn", ex.Message, "Aceptar");
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
