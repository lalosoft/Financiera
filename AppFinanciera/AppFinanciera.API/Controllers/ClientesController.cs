using AppFinanciera.API.BL;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppFinanciera.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    
    public class ClientesController : ControllerBase
    {
        private readonly ClientesBL _clientesBL;

        public ClientesController(ClientesBL bl)
        {
            _clientesBL = bl;
        }

        /// <summary>
        /// End-point para registrar un nuevo cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(ClienteTO cliente)
        {
            var result = await _clientesBL.AddCliente(cliente);
            return StatusCode(result.statusCode, result.message);
        }

        /// <summary>
        /// End-point para obtener los clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clientesBL.GetClientes();
            return StatusCode(result.statusCode, result.clientes);
        }
    }
}
