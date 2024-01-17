using Core.Domain;

namespace Core.Application.UseCases.Clientes.GetById
{
    public interface IRespGetById
    {
        void Ok(Cliente dto);
        void Error(string mensaje);
    }
}
