using Core.Application.Services;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.DataAccess
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ABanContext _context;

        public ClienteRepository(ABanContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> Search(string Nombre)
        {
            return await _context.Cliente.Where(
                cliente => cliente.Nombres.Contains(Nombre))
                .ToListAsync();
        }
    }
}
