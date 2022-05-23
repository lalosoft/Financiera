using AppFinanciera.API.Model;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFinanciera.API.BL
{
    public class ClientesBL
    {
        private readonly FinancieraContext _dbContext;

        public ClientesBL(FinancieraContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Metodo para registar un nuevo cliente en la BD
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<(int statusCode, string message)> AddCliente(ClienteTO cliente)
        {
            try
            {
                var newCliente = new Cliente() { Nombre = cliente.NombreCliente };
                _dbContext.Clientes.Add(newCliente);
                await _dbContext.SaveChangesAsync();
                return (StatusCodes.Status201Created, "Cliente creado exitosamente");
            }
            catch (System.Exception)
            {
                return (StatusCodes.Status500InternalServerError, "Error al agregar cliente");
            }
        }

        /// <summary>
        /// Metodo para obtener todos los clientes de la BD
        /// </summary>
        /// <returns></returns>
        public async Task<(int statusCode, List<ClienteTO> clientes)> GetClientes()
        {
            try
            {
                var res = await (from c in _dbContext.Clientes
                                 select new ClienteTO()
                                 {
                                     IdCliente = c.Id,
                                     NombreCliente = c.Nombre
                                 }).ToListAsync();

                return (StatusCodes.Status200OK, res);

            }
            catch (System.Exception)
            {
                return (StatusCodes.Status500InternalServerError, new List<ClienteTO>());
            }
        }
    }
}
