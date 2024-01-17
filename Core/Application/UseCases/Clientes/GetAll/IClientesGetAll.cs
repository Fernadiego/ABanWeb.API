using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.GetAll
{
    public interface IClientesGetAll
    {
        Task GetAll();
        void SetRespuesta(IRespuesta Respuesta);
    }
}
