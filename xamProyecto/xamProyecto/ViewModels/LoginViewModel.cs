using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace xamProyecto.ViewModels
{
    public class LoginViewModel
    {
        #region Propiedades
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EstaCorriendo { get; set; }
        public bool EstaRecordando { get; set; }
        public  ICommand ComandoLogin { get { return new RealayCommand(Login); } }
        #endregion

        #region Contructores
        public LoginViewModel()
        {
            this.EstaRecordando = true;
        }
        #endregion
    }
}
