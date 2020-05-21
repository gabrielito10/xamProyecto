
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using xamProyecto.Models;
using xamProyecto.Services;
using xamProyecto.ViewModels;

namespace xamProyecto.ViewModels
{ 
    public class PaisesViewModel: BaseViewModel
    {
        private ObservableCollection<ListaPaises> _Paises;
        private ApiService ServicioAPI;
        #region Propiedades
        public ObservableCollection<ListaPaises> Paises
        {
            get { return this._Paises; }
            set { SetValue(ref this._Paises, value); }
        }
        #endregion
        #region Contructores
      
        public PaisesViewModel()
        {
            this.ServicioAPI = new ApiService();
            this.CargarPaises();
        }
        #endregion
        #region Metodos
        private async void CargarPaises()
        {
            var Response = await this.ServicioAPI.GetList<ListaPaises>("http://restcountries.eu", "/rest", "/v2/all");
            if (!Response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", Response.Message, "Aceptar");
                return;
                
            }
            var lista = (List<ListaPaises>)Response.Result;
            this.Paises = new ObservableCollection<ListaPaises>(lista);
        }
        #endregion
    }
}
