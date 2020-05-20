﻿
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using xamProyecto.Models;
using xamProyecto.Services;
using xamProyecto.ViewModels;

namespace xamProyecto.ViewModels
{ 
    public class PaisesViewModel1: BaseViewModel
    {
        private ObservableCollection<Countries> _Paises;
        private ApiService ServicioAPI;
        #region Propiedades
        public ObservableCollection<Countries> Paises
        {
            get { return this._Paises; }
            set { SetValue(ref this._Paises, value); }
        }
        #endregion
        #region Contructores
      
        public PaisesViewModel1()
        {
            this.ServicioAPI = new ApiService();
            CargarPaises();
        }
        #endregion
        #region Metodos
        private async void CargarPaises()
        {
            var response = await this.ServicioAPI.GetList<Countries>("http://restcountries.eu", "/rest", "/v2/all");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
                var lista = (List<Countries>)response.Result;
                this.Paises = new ObservableCollection<Countries>(lista);
            }
        }
        #endregion
    }
}
