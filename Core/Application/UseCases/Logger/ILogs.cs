using Core.Domain;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Logger
{
    public interface ILogs
    {
        Task Write(Log Entidad);
    }
}
