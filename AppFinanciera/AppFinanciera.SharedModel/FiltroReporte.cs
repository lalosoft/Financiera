using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinanciera.SharedModel
{
    public class FiltroReporte
    {
        public int IdCliente { get; set; }
        public int IdCuenta { get; set; }
        public TipoTransaccion? TipoTransaccion { get; set; }
    }
}
