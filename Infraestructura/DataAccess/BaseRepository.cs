using Core.Application.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructura.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ABanContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ABanContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<T> GetById(int Id)
        {
           return await _dbSet.FindAsync(Id);
        }

        public async Task Insert(T Entidad)
        {
            await _dbSet.AddAsync(Entidad);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T Entidad)
        {
            _dbSet.Update(Entidad);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var Entidad = await _dbSet.FindAsync(Id);
            _dbSet.Remove(Entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exits(int Id)
        {
            if (Id == 0)
                return false;

            T ent = await _dbSet.FindAsync(Id);

            if (ent != null)
                return true;
            else
                return false;
        }
    }
}
