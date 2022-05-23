using System;
using System.Collections.Generic;

#nullable disable

namespace AppFinanciera.API.Model
{
    public partial class CuentaAhorro
    {
        public CuentaAhorro()
        {
            CuentaClientes = new HashSet<CuentaCliente>();
        }

        public int Id { get; set; }
        public int Saldo { get; set; }
        public int Cliente { get; set; }

        public virtual Cliente ClienteNavigation { get; set; }
        public virtual ICollection<CuentaCliente> CuentaClientes { get; set; }
    }
}
