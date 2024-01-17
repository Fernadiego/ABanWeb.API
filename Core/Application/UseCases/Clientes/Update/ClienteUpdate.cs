using Core.Application.Services;
using Core.Application.UseCases.Logger;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.Update
{
    public class ClienteUpdate : IClienteUpdate
    {
        IBaseRepository<Cliente> _context;
        private IRespuestaVoid _respuesta;
        private readonly ILogs _logger;

        public ClienteUpdate(IBaseRepository<Cliente> context, ILogs logger)
        {
            _context = context;
            _logger = logger;
        }

        public void SetRespuestaVoid(IRespuestaVoid Respuesta)
        {
            _respuesta = Respuesta;
        }

        public async Task Update(Cliente Entidad)
        {
            try
            {
                bool existe = await _context.Exits(Entidad.Id);
                if (!existe)
                    throw new Exception($"NO EXISTE EL ID={Entidad.Id} EN LA BASE DE DATOS.");

                await _context.Update(Entidad);
                _respuesta.Ok("ACTUALIZACION DE CLIENTE EXITOSA.");

                await _logger.Write(
                    new Log(ToString(), "OK", $"ACTUALIZACION DE CLIENTE EXITOSA. ID={Entidad.Id}", string.Empty));
            }
            catch (Exception ex)
            {
                _respuesta.Error(ex.Message);

                await _logger.Write(
                    new Log(ToString(), "ERROR", $"ACTUALIZACION DE CLIENTE. ID={Entidad.Id}", ex.Message));
            }

        }

        public override string ToString()
        {
            return "Cliente -> Update";
        }
    }
}
