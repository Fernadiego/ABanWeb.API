using Core.Domain;
using System.Collections.Generic;

namespace Core.Application.UseCases.Clientes
{
    public interface IRespuesta
    {
         void Ok(List<Cliente> dto);
         void Error(string mensaje);
    }
}
