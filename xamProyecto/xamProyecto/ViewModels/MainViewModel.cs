﻿namespace xamProyecto.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
       
        #region Contructures
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
        #endregion
    }
}
