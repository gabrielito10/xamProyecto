
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using xamProyecto.Models;
using xamProyecto.Services;
using xamProyecto.ViewModels;

namespace xamProyecto.ViewModels
{ 
    public class PaisesViewModel: BaseViewModel
    {
        private ObservableCollection<ListaPaises> _Paises;
        private ApiService _ServicioAPI;
        private bool _EstaRefrescando;
        private string _Filtro;
        private List<ListaPaises> _ListaPaises;
        #region Propiedades
        public ObservableCollection<ListaPaises> Paises
        {
            get { return this._Paises; }
            set { SetValue(ref this._Paises, value); }
        }

        public bool EstaRefrescando
        {
            get { return this._EstaRefrescando; }
            set { SetValue(ref this._EstaRefrescando, value);}
        }

        public string  Filtro
        {
            get { return this._Filtro; }
            set 
            { 
                SetValue(ref this._Filtro, value);
                this.Buscar();
            }
        }
        #endregion
        #region Contructores

        public PaisesViewModel()
        {
            this._ServicioAPI = new ApiService();
            this.CargarPaises();
        }
        #endregion
        #region Metodos
        private async void CargarPaises()
        {
            this.EstaRefrescando = true;
            var conexion = await this._ServicioAPI.CheckConnection();
            if(!conexion.IsSuccess)
            {
                this.EstaRefrescando = false;
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var Response = await this._ServicioAPI.GetList<ListaPaises>("http://restcountries.eu", "/rest", "/v2/all");
            if (!Response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", Response.Message, "Aceptar");
                return;
                
            }
            this._ListaPaises= (List<ListaPaises>)Response.Result;
            this.Paises = new ObservableCollection<ListaPaises>(_ListaPaises);
            this.EstaRefrescando = false;
        }
        #endregion

        public ICommand ComandoRefrescar
        {
            get
            {
                return new RelayCommand(CargarPaises);
            }
        }
        public ICommand ComandoBuscar
        {
            get
            {
                return new RelayCommand(Buscar);
            }
        }

        private void Buscar()
        {
            if (string.IsNullOrEmpty(this._Filtro))
                this.Paises = new ObservableCollection<ListaPaises>(this._ListaPaises);
            else
                this.Paises = new ObservableCollection<ListaPaises>(this._ListaPaises.Where(
                    l => l.Name.ToLower().Contains(this._Filtro.ToLower())||
                    l.Capital.ToLower().Contains(this._Filtro.ToLower())));
        }
    }
}
