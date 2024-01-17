using Core.Application.Services;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Logger
{
    public class Logs : ILogs
    {
        IBaseRepository<Log> _context;

        public Logs(IBaseRepository<Log> context)
        {
            _context = context;
        }

        public async Task Write(Log Entidad)
        {
            try
            {
                await _context.Insert(Entidad);
            }
            catch(Exception ex) 
            {
                string msg = ex.Message;
            }
        }
    }
}
