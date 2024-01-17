using Core.Application.Services;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.GetAll
{
    public class ClientesGetAll: IClientesGetAll
    {
        IBaseRepository<Cliente> _context;
        private IRespuesta _respuesta;

        public ClientesGetAll(IBaseRepository<Cliente> context)
        {
            _context = context;
        }

        public void SetRespuesta(IRespuesta Respuesta)
        {
            _respuesta = Respuesta;
        }

        public async Task GetAll()
        {
            try
            {
                _respuesta.Ok(_context.GetAll().ToList());
            }
            catch (Exception ex)
            {
                _respuesta.Error(ex.Message);
            }
        }
    }
}
