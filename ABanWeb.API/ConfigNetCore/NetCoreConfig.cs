using Core.Application.Services;
using Core.Application.UseCases.Clientes;
using Core.Application.UseCases.Clientes.Delete;
using Core.Application.UseCases.Clientes.GetAll;
using Core.Application.UseCases.Clientes.GetById;
using Core.Application.UseCases.Clientes.Insert;
using Core.Application.UseCases.Clientes.Update;
using Core.Application.UseCases.Logger;
using Core.Domain;
using Infraestructura.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace ABanWeb.API.ConfigNetCore
{
    public static class NetCoreConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();
            services.AddScoped<IBaseRepository<Log>, BaseRepository<Log>>();
            services.AddScoped<IBusquedaPorNombre, BusquedaPorNombre>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClientesGetAll, ClientesGetAll>();
            services.AddScoped<IClienteGetById, ClienteGetById>();
            services.AddScoped<IClienteInsert, ClienteInsert>();
            services.AddScoped<IClienteUpdate, ClienteUpdate>();
            services.AddScoped<IClienteDelete, ClienteDelete>();
            services.AddScoped<ILogs, Logs>();
            return services;
        }
    }
}
