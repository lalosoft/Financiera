using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinanciera.SharedModel
{
    public class CuentaClienteTO
    {
        public int IdCliente { get; set; }
        public int IdCuenta { get; set; }
        public int Saldo { get; set; }
        public string NombreCliente { get; set; }
    }
}
