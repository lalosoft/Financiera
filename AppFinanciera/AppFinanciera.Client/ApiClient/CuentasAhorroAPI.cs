using AppFinanciera.SharedModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppFinanciera.Client.ApiClient
{
    public class CuentasAhorroAPI : HttpClient
    {
        public CuentasAhorroAPI(string rootUrl)
        {
            rootUrl += (rootUrl.EndsWith('/')) ? "CuentaAhorros/" : "/CuentaAhorros/";
            BaseAddress = new Uri(rootUrl);
        }

        public async Task<List<CuentaClienteTO>> GetCuentasByCte(int idCte)
        {
            var res = await this.GetFromJsonAsync<List<CuentaClienteTO>>($"{idCte}");
            return res;
        }

        public async Task<string> RegistrarCuentaAsync(CuentaAhorroTO cuenta) 
        {
            var res = await this.PostAsJsonAsync("", cuenta);
            if (res.StatusCode == System.Net.HttpStatusCode.Created) return "Cuenta creada";
            else return "Error al crear la cuenta";
        }

        public async Task<string> OperacionCuentaAsync(TransaccionTO transaccion)
        {
            string msg = string.Empty;
            
            switch (transaccion.TipoTransaccion)
            {
                case TipoTransaccion.Deposito:
                    var res = await this.PostAsJsonAsync("Depositar", transaccion);
                    if (res.StatusCode == System.Net.HttpStatusCode.OK) msg = "Deposito realizado";
                    else msg = "Error al realizar el deposito";
                    break;
                    
                case TipoTransaccion.Retiro:
                    var response = await this.PostAsJsonAsync("Retirar", transaccion);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK) msg = "Retiro realizado";
                    else msg = "Error al realizar el retiro";
                    break;
            }
            return msg;
        }
    }
}
