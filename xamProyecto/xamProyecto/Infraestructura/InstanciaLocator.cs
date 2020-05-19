using System;
using System.Collections.Generic;
using System.Text;
using xamProyecto.ViewModels;

namespace xamProyecto.Infraestructura
{
    class InstanciaLocator
    {
        public MainViewModel Main { get; set; }

        public InstanciaLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
