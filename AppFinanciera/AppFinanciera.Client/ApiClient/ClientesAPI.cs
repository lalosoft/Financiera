using AppFinanciera.SharedModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppFinanciera.Client.ApiClient
{
    public class ClientesAPI : HttpClient
    {
        public ClientesAPI(string rootUrl)
        {
            rootUrl += (rootUrl.EndsWith('/')) ? "Clientes/" : "/Clientes/";
            BaseAddress = new Uri(rootUrl);
        }

        public async Task<List<ClienteTO>> GetClientesAsync()
        {
            var res = await this.GetFromJsonAsync<List<ClienteTO>>("");
            return res;
        }

        public async Task<string> AddCliente(ClienteTO cliente) 
        {
            var res = await this.PostAsJsonAsync("", cliente);
            if (res.StatusCode == System.Net.HttpStatusCode.Created)
                return "Cliente creado con exito";
            else return "No se pudo registrar al cliente";
        }
    }
}
