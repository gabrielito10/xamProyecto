using System;
using System.Collections.Generic;
using System.Text;

namespace xamProyecto.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public PaisesViewModel Paises { get; set; }

        #region Contructures
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            //this.Paises = new PaisesViewModel();
         }
        #endregion

        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();
            return instance;
        }
    }
}
