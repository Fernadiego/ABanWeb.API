using Core.Application.Services;
using Core.Application.UseCases.Logger;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.Delete
{
    public class ClienteDelete : IClienteDelete
    {
        IBaseRepository<Cliente> _context;
        private IRespuestaVoid _respuesta;
        private readonly ILogs _logger;

        public ClienteDelete(IBaseRepository<Cliente> context, ILogs logger)
        {
            _context = context;
            _logger = logger;
        }

        public void SetRespuestaVoid(IRespuestaVoid Respuesta)
        {
            _respuesta = Respuesta;
        }

        public async Task Delete(int Id)
        {
            try
            {
                bool existe = await _context.Exits(Id);
                if (!existe)
                    throw new Exception($"NO EXISTE EL ID={Id} EN LA BASE DE DATOS.");

                await _context.Delete(Id);
                _respuesta.Ok("ELIMINACION DE CLIENTE EXITOSA.");

                await _logger.Write(
                    new Log(ToString(), "OK", $"ELIMINACION DE CLIENTE EXITOSA. ID={Id}", string.Empty));
            }
            catch (Exception ex)
            {
                _respuesta.Error(ex.Message);

                await _logger.Write(
                    new Log(ToString(), "ERROR", $"ELIMINACION DE CLIENTE. ID={Id}", ex.Message));
            }
        }

        public override string ToString()
        {
            return "Cliente -> Delete";
        }
    }
}
