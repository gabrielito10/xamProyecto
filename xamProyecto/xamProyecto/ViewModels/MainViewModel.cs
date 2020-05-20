using System;
using System.Collections.Generic;
using System.Text;

namespace xamProyecto.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        internal ListaPaisesViewModel Lista { get; set; }

        #region Contructures
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
            
         }
        #endregion
    }
}
