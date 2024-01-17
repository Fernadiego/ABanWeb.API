
namespace Core.Application.UseCases.Clientes
{
    public interface IRespuestaVoid
    {
        void Ok(string mensaje);
        void Error(string mensaje);
    }
}
