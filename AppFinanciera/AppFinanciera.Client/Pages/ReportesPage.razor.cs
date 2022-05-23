using AppFinanciera.Client.BL;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFinanciera.Client.Pages
{
    public partial class ReportesPage
    {
        [Inject] public ClientesBL ClientesBL { get; set; }
        [Inject] public CuentasAhorroBL CuentasAhorroBL { get; set; }
        [Inject] public ReportesBL ReportesBL { get; set; }

        List<ClienteTO> clientes = new List<ClienteTO>();
        List<CuentaClienteTO> cuentas = new List<CuentaClienteTO>();
        List<ReporteTO> reporteMov = new List<ReporteTO>();
        int clienteSelected = 0;
        int cuentaSelected = 0;
        FiltroReporte filtroReporte = new FiltroReporte();

        protected override async Task OnInitializedAsync()
        {
            await GetClientes();
            await GetCuentasCliente();
            
            filtroReporte.IdCuenta = cuentaSelected;
            filtroReporte.IdCliente = clienteSelected;

            await Reporte();
        }

        public async void OnChangeCliente(ChangeEventArgs e)
        {
            clienteSelected = int.Parse(e.Value.ToString());
            filtroReporte.IdCliente = clienteSelected;
            await GetCuentasCliente();
            
            if(cuentaSelected != 0)
            {
                filtroReporte.IdCuenta = cuentaSelected;
                await Reporte();
            }
        }

        public async void OnChangeCuenta(ChangeEventArgs e)
        {
            cuentaSelected = int.Parse(e.Value.ToString());
            filtroReporte.IdCuenta = cuentaSelected;
            await Reporte();
        }

        async Task GetClientes()
        {
            clientes = await ClientesBL.GetClientes();
            clienteSelected = clientes.FirstOrDefault().IdCliente;
        }

        async Task GetCuentasCliente()
        {
            try
            {
                cuentas.Clear();
                cuentas = await CuentasAhorroBL.GetCtasByCte(clienteSelected);
                cuentaSelected = cuentas.FirstOrDefault().IdCuenta;
                Console.WriteLine(cuentaSelected);
            }
            catch (Exception)
            {
                reporteMov.Clear();
            }
            
            StateHasChanged();
        }

        async Task Reporte()
        {
            reporteMov.Clear();
            reporteMov = await ReportesBL.GetReporte(filtroReporte);
            StateHasChanged();
        }
    }
}
