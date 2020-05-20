using System;
using System.Collections.Generic;
using System.Text;

namespace xamProyecto.Models
{
    public class Respuesta
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
