using AppFinanciera.Client.ApiClient;
using AppFinanciera.SharedModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFinanciera.Client.BL
{
    public class CuentasAhorroBL
    {
        private CuentasAhorroAPI cuentasAhorroAPI;

        public CuentasAhorroBL(CuentasAhorroAPI api)
        {
            cuentasAhorroAPI = api;
        }

        public async Task<List<CuentaClienteTO>> GetCtasByCte(int idCte) 
            => await cuentasAhorroAPI.GetCuentasByCte(idCte);

        public async Task<string> RegistrarCuenta(CuentaAhorroTO cuenta) 
            => await cuentasAhorroAPI.RegistrarCuentaAsync(cuenta);

        public async Task<string> OperacionCuenta(TransaccionTO transaccion) 
            => await cuentasAhorroAPI.OperacionCuentaAsync(transaccion);
    }
}
