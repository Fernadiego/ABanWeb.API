using Core.Domain;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.Update
{
    public interface IClienteUpdate
    {
        Task Update(Cliente Entidad);
        void SetRespuestaVoid(IRespuestaVoid Respuesta);
    }
}
