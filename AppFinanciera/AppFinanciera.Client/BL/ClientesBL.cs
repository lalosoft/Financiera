using AppFinanciera.Client.ApiClient;
using AppFinanciera.SharedModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFinanciera.Client.BL
{
    public class ClientesBL
    {
        private ClientesAPI clientesAPI;

        public ClientesBL(ClientesAPI api)
        {
            clientesAPI = api;
        }

        public async Task<List<ClienteTO>> GetClientes() => await clientesAPI.GetClientesAsync();
        
        public async Task<string> RegistrarCliente(ClienteTO cliente) => await clientesAPI.AddCliente(cliente);
    }
}
