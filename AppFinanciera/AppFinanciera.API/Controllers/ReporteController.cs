using AppFinanciera.API.BL;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppFinanciera.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    
    public class ReporteController : ControllerBase
    {
        private readonly ReportesBL _reportesBL;

        public ReporteController(ReportesBL bl)
        {
            _reportesBL = bl;
        }

        /// <summary>
        /// End-point para obtener el reporte de movimientos de una cuenta
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet("{idCliente}/{idCuenta}")]
        public async Task<IActionResult> GetHistorialTransacc(int idCliente, int idCuenta)
        {
            var res = await _reportesBL.GetTransaccionesByCtaCte(new FiltroReporte { IdCliente = idCliente, IdCuenta = idCuenta });
            return StatusCode(res.statusCode, res.historicoCta);
        }
    }
}
