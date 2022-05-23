using System;
using System.Collections.Generic;

#nullable disable

namespace AppFinanciera.API.Model
{
    public partial class CuentaCliente
    {
        public int Id { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public byte TipoTransaccion { get; set; }
        public int Monto { get; set; }
        public int Cliente { get; set; }
        public int Cuenta { get; set; }

        public virtual Cliente ClienteNavigation { get; set; }
        public virtual CuentaAhorro CuentaNavigation { get; set; }
    }
}
