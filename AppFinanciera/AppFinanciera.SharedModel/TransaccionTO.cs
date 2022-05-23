using System;
using System.Collections.Generic;
using System.Text;
using AppFinanciera.SharedModel;

namespace AppFinanciera.SharedModel
{
    public class TransaccionTO
    {
        public int IdCliente { get; set; }
        public int IdCuenta { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }
        public int Monto { get; set; }
        
    }
}
