using photosStarWars;
using photosStarWars.Views;
using photosStarWars.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace photosStarWars.VM
{
    public class VMlogin : BaseViewModel
    {
        #region VARIABLES
        private string _nombre;
        private string _password;
        #endregion
        #region CONSTRUCTOR
        public VMlogin(INavigation navigation)
        {
            nombre = "";
            password = "";
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string nombre
        {
            get { return _nombre; }
            set { SetValue(ref _nombre, value); }
        }
        public string password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }
        #endregion
        #region PROCESOS

        #endregion
        #region COMANDOS
        public ICommand ingresarCommand => new Command(async () => await ingresarClicked());
        public ICommand registroCommand => new Command(async () => await registroClicked());
        public INavigation Navigation { get; }
        #endregion
        #region BotonesMenu
        public async Task ingresarClicked()
        {
            if (validarDatos())
            {
                try
                {
                    usuario aux = new usuario();
                    aux = await App.SQliteDB.getUsuarioName(_nombre);

                    if (aux.password.Equals(_password))
                    {
                        await Navigation.PushAsync(new photo());
                    }
                    else
                    {
                        _nombre = "";
                        _password = "";
                        await DisplayAlert("Error", "Datos Incorrectos", "Aceptar");
                    }

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "Aceptar");
                }

            }
            else
            {
                DisplayAlert("Error", "Datos Incompletos", "Aceptar");
            }

        }

        public bool validarDatos()
        {
            bool respuesta = true;

            if (string.IsNullOrEmpty(_nombre))
            {
                respuesta = false;

            }
            else if (string.IsNullOrEmpty(_password))
            {
                respuesta = false;
            }
            return respuesta;
        }
        public async Task registroClicked()
        {
            await Navigation.PushAsync(new registro());
        }
        #endregion
        #region BOTONES SALIDA
        #endregion
    }
}

