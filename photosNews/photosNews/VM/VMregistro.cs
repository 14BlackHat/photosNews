using photosStarWars;
using photosStarWars.Views;
using photosStarWars.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace photosStarWars.VM
{
    public class VMregistro : BaseViewModel
    {
        #region VARIABLES
        private string _usuario;
        private string _password;
        private string _email;
        private string _confirmPassword;
        #endregion
        #region CONSTRUCTOR
        public VMregistro(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string nombre
        {
            get { return _usuario; }
            set { SetValue(ref _usuario, value); }
        }
        public string password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }
        public string email
        {
            get { return _email; }
            set { SetValue(ref _email, value); }
        }
        public string confirmPassword
        {
            get { return _confirmPassword; }
            set { SetValue(ref _confirmPassword, value); }
        }
        #endregion
        #region PROCESOS
        public async Task cancelar()
        {
            nombre = "";
            email = "";
            password = "";
            confirmPassword = "";

            await Navigation.PopToRootAsync();
        }
        public async Task registrar()
        {
            if (validarDatos())
            {
                usuario usuaio = new usuario()
                {
                    nombre = nombre,
                    email = email,
                    password = password
                };
                try
                {
                    await App.SQliteDB.guardarAlumno(usuaio);
                    nombre = "";
                    email = "";
                    password = "";
                    confirmPassword = "";

                    await DisplayAlert("Registro", "Se guardo correctamente el usuario", "Aceptar");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.Message, "Aceptar");
                }

                await Navigation.PopToRootAsync();
            }
            else
            {
                await DisplayAlert("Advertencia", "Error al Ingresar los datos", "Aceptar");
            }
        }

        public bool validarDatos()
        {
            bool respuesta = true;

            if (string.IsNullOrEmpty(_usuario))
            {
                respuesta = false;

            }
            else if (string.IsNullOrEmpty(_email))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(_password))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(_confirmPassword))
            {
                respuesta = false;
            }
            else if (!_confirmPassword.Equals(_password))
            {
                password = "";
                confirmPassword = "";
                respuesta = false;
            }
            return respuesta;
        }

        #endregion
        #region COMANDOS
        public ICommand guardarCommand => new Command(async () => await registrar());
        public ICommand cancelarCommand => new Command(async () => await cancelar());
        public INavigation Navigation { get; }
        #endregion
        #region BotonesMenu

        #endregion
        #region BOTONES SALIDA
        #endregion
    }
}
