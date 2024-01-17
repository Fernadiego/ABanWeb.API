using System.Threading.Tasks;

namespace Core.Application.UseCases.Clientes
{
    public interface IBusquedaPorNombre
    {
        Task SearchByName(string Nombre);
        void SetRespuesta(IRespuesta Respuesta);
    }
}
