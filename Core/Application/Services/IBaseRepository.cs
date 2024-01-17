using System.Linq;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Obtener todos los registros de la tabla.
        /// </summary>
        public IQueryable<T> GetAll();

        /// <summary>
        /// Obtener un registro por Id
        /// </summary>
        /// <param name="Id"></param>
        public Task<T> GetById(int Id);

        /// <summary>
        /// Crear registros nuevos
        /// </summary>
        /// <param name="Entidad"></param>
        public Task Insert(T Entidad);

        /// <summary>
        /// Actualizar Registros
        /// </summary>
        /// <param name="Entidad"></param>
        public Task Update(T Entidad);

        /// <summary>
        /// Para eliminar registros
        /// </summary>
        /// <param name="Id"></param>
        public Task Delete(int Id);

        /// <summary>
        /// Cpmprobar existencia de la Entidad
        /// </summary>
        /// <param name="Id"></param>
        public Task<bool> Exits(int Id);

    }
}
