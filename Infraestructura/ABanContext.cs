
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class ABanContext : DbContext
    {
        public ABanContext()
        {
        }

        public ABanContext(DbContextOptions<ABanContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Log> Log { get; set; }
    }
}
