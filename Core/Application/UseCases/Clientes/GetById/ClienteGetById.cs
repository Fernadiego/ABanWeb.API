using Core.Application.Services;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.GetById
{
    public class ClienteGetById : IClienteGetById
    {
        IBaseRepository<Cliente> _context;
        private IRespGetById _respuesta;

        public ClienteGetById(IBaseRepository<Cliente> context)
        {
            _context = context;
        }

        public void SetRespuesta(IRespGetById Respuesta)
        {
            _respuesta = Respuesta;
        }

        public async Task GetById(int Id)
        {
            try
            {
                _respuesta.Ok(await _context.GetById(Id));
            }
            catch (Exception ex)
            {
                _respuesta.Error(ex.Message);
            }
        }
    }
}
