using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes.GetById
{
    public interface IClienteGetById
    {
        Task GetById(int Id);
        void SetRespuesta(IRespGetById Respuesta);
    }
}
