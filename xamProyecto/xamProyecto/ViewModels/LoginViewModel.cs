using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xamProyecto.Views;

namespace xamProyecto.ViewModels
{

    public class LoginViewModel : BaseViewModel //INotifyPropertyChanged
    {
        
        private string _Password;
        private bool _EstaCorriendo;
        private bool _EstaRecordando;
        private string _Email = "";
        /*public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                if (_Password != value)
                {
                    this._Password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangingEventArgs(nameof(this._Password)));
                }
            }
        }*/
        #region Propiedades

        public string Email
        {
            get { return this._Email; }
            set { SetValue(ref this._Email, value); }
        }
        public string Password
        {
            get { return this._Password; }
            set { SetValue(ref this._Password, value); }
        }
        public bool EstaCorriendo
        {
            get { return this._EstaCorriendo; }
            set { SetValue(ref this._EstaCorriendo, value); }
        }
        public bool EstaRecordando
        {
            get { return this._EstaRecordando; }
            set { SetValue(ref this._EstaRecordando, value); }
        }

        #endregion

        #region Contructores
        public LoginViewModel()
        {
            this.EstaRecordando = true;
        }
        #endregion

        #region Comandos
        public ICommand ComandoLogin { get { return new RelayCommand(Login); } }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingrese Email", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingrese Contraseña", "Aceptar");
                return;
            }
            this.EstaCorriendo = true;
            if (this.Email != "gabo@gmail.com" || this.Password != "1234")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El Usuario o la contraseña no son validos", "Aceptar");
                Password = string.Empty;
                this.EstaCorriendo = false;
                return;
            }
            this.EstaCorriendo = false;
            //await Application.Current.MainPage.Navigation.PushAsync(new PaisesPage());
        }
        #endregion
    }
}
