using AppFinanciera.API.BL;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppFinanciera.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaAhorrosController : ControllerBase
    {
        private readonly CuentaAhorroBL _cuentaAhorroBL;

        public CuentaAhorrosController(CuentaAhorroBL bl)
        {
            _cuentaAhorroBL = bl;
        }

        /// <summary>
        /// End-point para registrar una cuenta de ahorro
        /// </summary>
        /// <param name="cuentaAhorro"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CuentaAhorroTO cuentaAhorro)
        {
            var res = await _cuentaAhorroBL.AddCuenta(cuentaAhorro);
            return StatusCode(res.statusCode, res.message);
        }

        /// <summary>
        /// End-point para obtener el listado de cuentas por cliente
        /// </summary>
        /// <param name="idCte"></param>
        /// <returns></returns>
        [HttpGet("{idCte}")]
        public async Task<IActionResult> GetCtasByCte(int idCte)
        {
            var res = await _cuentaAhorroBL.GetCtasByCteAsync(idCte);
            return StatusCode(res.statusCode, res.cuentasCliente);
        }

        /// <summary>
        /// End-point para ingresar dinero en una cuenta
        /// </summary>
        /// <param name="transaccion"></param>
        /// <returns></returns>
        [HttpPost("Depositar")]
        public async Task<IActionResult> Depositar(TransaccionTO transaccion)
        {
            var res = await _cuentaAhorroBL.DepositoAsync(transaccion);
            return StatusCode(res.statusCode, res.message);
        }

        /// <summary>
        /// End-point para retirar dinero de una cuenta
        /// </summary>
        /// <param name="transaccion"></param>
        /// <returns></returns>
        [HttpPost("Retirar")]
        public async Task<IActionResult> Retirar(TransaccionTO transaccion)
        {
            var res = await _cuentaAhorroBL.RetirarAsync(transaccion);
            return StatusCode(res.statusCode, res.message);
        }
    }
}
