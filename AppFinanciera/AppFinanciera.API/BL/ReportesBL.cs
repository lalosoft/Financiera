using AppFinanciera.API.Model;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFinanciera.API.BL
{
    public class ReportesBL
    {
        private readonly FinancieraContext _dbcontext;

        public ReportesBL(FinancieraContext context)
        {
            _dbcontext = context;
        }

        /// <summary>
        /// Obtiene el historico de movimientos por cuenta y por cliente
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public async Task<(int statusCode, List<ReporteTO> historicoCta)> GetTransaccionesByCtaCte(FiltroReporte filtro)
        {
            try
            {
                var listHistorico = new List<ReporteTO>();
                listHistorico = await (from cc in _dbcontext.CuentaClientes
                                       where cc.Cliente == filtro.IdCliente
                                             && cc.Cuenta == filtro.IdCuenta
                                       orderby cc.FechaTransaccion descending
                                       select new ReporteTO
                                       {
                                           FechaTransaccion = cc.FechaTransaccion,
                                           Monto = cc.Monto,
                                           Tipo = (cc.TipoTransaccion == 1 ? "Depósito" : "Retiro")
                                       }).ToListAsync();
                return (StatusCodes.Status200OK, listHistorico);
            }
            catch (System.Exception)
            {
                return (StatusCodes.Status500InternalServerError, null);
            }
        }
    }
}
