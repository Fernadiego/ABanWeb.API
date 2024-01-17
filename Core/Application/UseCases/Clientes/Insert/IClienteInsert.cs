using Core.Domain;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.Insert
{
    public interface IClienteInsert
    {
        Task Insert(Cliente Entidad);
        void SetRespuestaVoid(IRespuestaVoid Respuesta);
    }
}
