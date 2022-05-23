using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinanciera.SharedModel
{
    public class ReporteTO
    {
        public DateTime FechaTransaccion { get; set; }
        public string Tipo { get; set; }
        public int Monto { get; set; }
    }
}
