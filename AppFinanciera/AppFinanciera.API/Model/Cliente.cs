using System;
using System.Collections.Generic;

#nullable disable

namespace AppFinanciera.API.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            CuentaAhorros = new HashSet<CuentaAhorro>();
            CuentaClientes = new HashSet<CuentaCliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CuentaAhorro> CuentaAhorros { get; set; }
        public virtual ICollection<CuentaCliente> CuentaClientes { get; set; }
    }
}
