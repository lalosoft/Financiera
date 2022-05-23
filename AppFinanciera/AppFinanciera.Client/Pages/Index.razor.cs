using AppFinanciera.Client.BL;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFinanciera.Client.Pages
{
    public partial class Index
    {
        [Inject] public ClientesBL ClientesBL { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        private string style = "display:none";
        ClienteTO cliente = new ClienteTO();
        List<ClienteTO> listClientes = new List<ClienteTO>();

        protected override async Task OnInitializedAsync()
        {
            await GetClientes();
        }
        
        async Task GetClientes()
        {
            listClientes.Clear();
            listClientes = await ClientesBL.GetClientes();
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

        async Task GuardarCliente()
        {
            var msg = await ClientesBL.RegistrarCliente(cliente);
            cliente.NombreCliente = "";
            await GetClientes();
            style = "display:none";
            StateHasChanged();
        }

        void CuentasAhorro(int idCte)
        {
            NavigationManager.NavigateTo($"cuentas-ahorro/{idCte}");
        }
    }
}
