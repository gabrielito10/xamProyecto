﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace xamProyecto.ViewModels
{
    public class PaisesViewModel : BaseViewModel
    {
        public PaisesViewModel()
        {
            CargarPaises();
        }
        private async void CargarPaises()
        {
            
                await Application.Current.MainPage.DisplayAlert("Error", "hola", "Aceptar");
            
        }
    }
}
