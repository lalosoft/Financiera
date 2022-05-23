using AppFinanciera.Client.BL;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFinanciera.Client.Pages
{
    public partial class CuentasAhorroPage
    {
        private int id;
        [Parameter] 
        public int Id 
        {
            get { return id; }
            set
            {
                id = value;
            } 
        }

        [Inject] public CuentasAhorroBL CuentasAhorroBL { get; set; }

        private string style = "display:none";
        private string styleTransacc = "display:none";
        
        List<CuentaClienteTO> cuentasCliente = new List<CuentaClienteTO>();
        CuentaAhorroTO cuentaAhorro = new CuentaAhorroTO();
        TransaccionTO transaccion = new TransaccionTO();
        int saldoCuenta = 0;
        string mensaje = "";

        protected override async Task OnInitializedAsync()
        {
            await GetCuentasCliente();
        }

        async Task GetCuentasCliente()
        {
            cuentasCliente = await CuentasAhorroBL.GetCtasByCte(Id);
        }

        void AbrirModal()
        {
            style = "display:block";
            StateHasChanged();
        }

        void CerrarModal()
        {
            style = "display:none";
            StateHasChanged();
        }

        async Task GuardarCuenta(int idCte)
        {
            cuentaAhorro.IdCliente = idCte;
            var res = await CuentasAhorroBL.RegistrarCuenta(cuentaAhorro);
            cuentaAhorro.Saldo = 0;
            await GetCuentasCliente();
            style = "display:none";
            StateHasChanged();

        }

        void AbrirModalTransaccion(int idCuenta, TipoTransaccion tipoTransaccion, int saldoAct)
        {
            styleTransacc = "display:block";
            saldoCuenta = saldoAct;
            transaccion.IdCuenta = idCuenta;
            transaccion.IdCliente = Id;
            transaccion.TipoTransaccion = tipoTransaccion;
            StateHasChanged();
        }

        void CerrarModalDeposito()
        {
            styleTransacc = "display:none";
            StateHasChanged();
        }

        async Task Transaccion()
        {
            if (transaccion.TipoTransaccion == TipoTransaccion.Retiro && transaccion.Monto > saldoCuenta)
            {
                mensaje = "Saldo insuficiente";
                await Task.Delay(TimeSpan.FromSeconds(3));
                mensaje = "";
            }

            else
            {
                var res = await CuentasAhorroBL.OperacionCuenta(transaccion);
                transaccion.Monto = 0;
                await GetCuentasCliente();
                styleTransacc = "display:none";
            }
            StateHasChanged();
        }
    }
}
