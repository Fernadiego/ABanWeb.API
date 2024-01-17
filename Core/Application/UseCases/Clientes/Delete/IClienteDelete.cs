using Core.Domain;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.Delete
{
    public interface IClienteDelete
    {
        Task Delete(int Id);
        void SetRespuestaVoid(IRespuestaVoid Respuesta);
    }
}
