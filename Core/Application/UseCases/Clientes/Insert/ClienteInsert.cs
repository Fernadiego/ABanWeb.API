using Core.Application.Services;
using Core.Application.UseCases.Logger;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.Insert
{
    public class ClienteInsert : IClienteInsert
    {
        IBaseRepository<Cliente> _context;
        private IRespuestaVoid _respuesta;
        private readonly ILogs _logger;

        public ClienteInsert(IBaseRepository<Cliente> context, ILogs logger)
        {
            _context = context;
            _logger = logger;
        }

        public void SetRespuestaVoid(IRespuestaVoid Respuesta)
        {
            _respuesta = Respuesta;
        }

        public async Task Insert(Cliente Entidad)
        {
            try
            {
                await _context.Insert(Entidad);
                _respuesta.Ok("ALTA DE CLIENTE EXITOSA.");

                await _logger.Write(
                    new Log(ToString(), "OK", $"ALTA DE CLIENTE EXITOSA. ID={Entidad.Id}", string.Empty));
            }
            catch (Exception ex)
            {
                _respuesta.Error(ex.Message);

                await _logger.Write(
                    new Log(ToString(), "ERROR", $"ALTA DE CLIENTE. ID={Entidad.Id}", ex.Message));
            }
        }

        public override string ToString()
        {
            return "Cliente -> Insert";
        }
    }
}
