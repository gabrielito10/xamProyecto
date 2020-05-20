using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace xamProyecto.ViewModels
{
    class ListaPaisesViewModel :BaseViewModel
    {
        public ListaPaisesViewModel()
        {
            CargarPaises();
        }
        private async void CargarPaises()
        {

            await Application.Current.MainPage.DisplayAlert("Error", "hola", "Aceptar");

        }
    }
}
