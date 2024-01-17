using Core.Application.Services;
using Core.Application.UseCases.Logger;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes
{
    public class BusquedaPorNombre : IBusquedaPorNombre
    {
        private readonly IClienteRepository _repoCliente;
        private IRespuesta _respuesta;
        private readonly ILogs _logger;

        public BusquedaPorNombre(IClienteRepository repoCliente, ILogs logger)
        {
            _repoCliente = repoCliente;
            _logger = logger;
        }

        public void SetRespuesta(IRespuesta Respuesta)
        {
            _respuesta = Respuesta;
        }

        public async Task SearchByName(string Nombre)
        {
            try
            {
                _respuesta.Ok(await _repoCliente.Search(Nombre));

                await _logger.Write(
                    new Log(ToString(), "OK", $"SEARCH RESULTS. NOMBRE={Nombre}", string.Empty));
            }
            catch(Exception ex)
            {
                _respuesta.Error(ex.Message);

                await _logger.Write(
                    new Log(ToString(), "ERROR", $"SEARCH RESULTS. NOMBRE={Nombre}", ex.Message));
            }
        }

        public override string ToString()
        {
            return "Cliente -> BusquedaPorNombre";
        }
    }
}
