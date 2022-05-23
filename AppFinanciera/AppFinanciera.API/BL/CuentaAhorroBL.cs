using AppFinanciera.API.Model;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppFinanciera.API.BL
{
    public class CuentaAhorroBL
    {
        private readonly FinancieraContext _dbContext;

        public CuentaAhorroBL(FinancieraContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Metodo para crear una cuenta de ahorro
        /// </summary>
        /// <param name="cuentaAhorro"></param>
        /// <returns></returns>
        public async Task<(int statusCode, string message)> AddCuenta(CuentaAhorroTO cuentaAhorro)
        {
            try
            {
                var newCtaAhorro = new CuentaAhorro()
                {
                    Cliente = cuentaAhorro.IdCliente,
                    Saldo = cuentaAhorro.Saldo
                };

                _dbContext.CuentaAhorros.Add(newCtaAhorro);
                await _dbContext.SaveChangesAsync();

                return (StatusCodes.Status201Created, "Cuenta de ahorro creada");
            }
            catch (System.Exception)
            {
                return (StatusCodes.Status500InternalServerError, "Error al registrar la cuenta");
            }
        }

        /// <summary>
        /// Metodo para obtener las cuentas de ahorro de un cliente
        /// </summary>
        /// <param name="idCte"></param>
        /// <returns></returns>
        public async Task<(int statusCode, List<CuentaClienteTO> cuentasCliente)> GetCtasByCteAsync(int idCte)
        {
            try
            {
                var ctasCte = await (from c in _dbContext.Clientes
                                     join ca in _dbContext.CuentaAhorros on c.Id equals ca.Cliente
                                     where c.Id == idCte
                                     select new CuentaClienteTO
                                     {
                                         IdCuenta = ca.Id,
                                         IdCliente = ca.Cliente,
                                         Saldo = ca.Saldo,
                                         NombreCliente = c.Nombre
                                     }).ToListAsync();

                return (StatusCodes.Status200OK, ctasCte);
            }
            catch (System.Exception)
            {
                return (StatusCodes.Status500InternalServerError, new List<CuentaClienteTO>());
            }
        }

        /// <summary>
        /// Metodo para depositar dinero en una cuenta de ahorro
        /// </summary>
        /// <param name="transaccion"></param>
        /// <returns></returns>
        public async Task<(int statusCode, string message)> DepositoAsync(TransaccionTO transaccion) 
        {
            try
            {
                var ctaCliente = await _dbContext.CuentaAhorros.Where(c => c.Id == transaccion.IdCuenta && 
                                        c.Cliente == transaccion.IdCliente)
                                        .FirstOrDefaultAsync();
                
                if (ctaCliente == null) return (StatusCodes.Status404NotFound, "Cuenta no encontrada");

                var newTransacc = new CuentaCliente()
                {
                    Cuenta = transaccion.IdCuenta,
                    Cliente = transaccion.IdCliente,
                    FechaTransaccion = DateTime.Now,
                    Monto = transaccion.Monto,
                    TipoTransaccion = (byte)transaccion.TipoTransaccion
                };

                _dbContext.CuentaClientes.Add(newTransacc);
                ctaCliente.Saldo += transaccion.Monto;
                _dbContext.CuentaAhorros.Update(ctaCliente);
                await _dbContext.SaveChangesAsync();

                return (StatusCodes.Status200OK, "Deposito realizado con exito");
            }
            catch (System.Exception)
            {
                return (StatusCodes.Status500InternalServerError, "Error al registrar el deposito");
            }
        }

        /// <summary>
        /// Metodo para retirar dinero en una cuenta de ahorro
        /// </summary>
        /// <param name="transaccion"></param>
        /// <returns></returns>
        public async Task<(int statusCode, string message)> RetirarAsync(TransaccionTO transaccion)
        {
            try
            {
                var ctaCliente = await _dbContext.CuentaAhorros.Where(c => c.Id == transaccion.IdCuenta &&
                                        c.Cliente == transaccion.IdCliente)
                                        .FirstOrDefaultAsync();

                if (ctaCliente == null) return (StatusCodes.Status404NotFound, "Cuenta no encontrada");

                var newTransacc = new CuentaCliente()
                {
                    Cuenta = transaccion.IdCuenta,
                    Cliente = transaccion.IdCliente,
                    FechaTransaccion = DateTime.Now,
                    Monto = transaccion.Monto,
                    TipoTransaccion = (byte)transaccion.TipoTransaccion
                };

                _dbContext.CuentaClientes.Add(newTransacc);
                ctaCliente.Saldo -= transaccion.Monto;
                _dbContext.CuentaAhorros.Update(ctaCliente);
                await _dbContext.SaveChangesAsync();

                return (StatusCodes.Status200OK, "Retiro realizado con exito");
            }
            catch (System.Exception)
            {
                return (StatusCodes.Status500InternalServerError, "Error al registrar el deposito");
            }
        }
    }
}
