using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public interface IClienteRepository
    {
        /// <summary>
        /// Búsqueda por nombre
        /// </summary>
        public Task<List<Cliente>> Search(string Nombre);
    }
}
