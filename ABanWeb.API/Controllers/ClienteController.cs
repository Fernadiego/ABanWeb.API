using ABanWeb.API.DTOs;
using Core.Application.UseCases.Clientes;
using Core.Application.UseCases.Clientes.Delete;
using Core.Application.UseCases.Clientes.GetAll;
using Core.Application.UseCases.Clientes.GetById;
using Core.Application.UseCases.Clientes.Insert;
using Core.Application.UseCases.Clientes.Update;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABanWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase, IRespuesta, IRespGetById, IRespuestaVoid
    {
        private IActionResult _response;

        [ApiExplorerSettings(IgnoreApi = true)]
        void IRespuesta.Ok(List<Cliente> response)
        {
            _response = Ok(response);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        void IRespuesta.Error(string mensaje) 
        { 
            _response = StatusCode(StatusCodes.Status500InternalServerError, mensaje);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        void IRespGetById.Ok(Cliente response)
        {
            _response = Ok(response);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        void IRespGetById.Error(string mensaje)
        {
            _response = StatusCode(StatusCodes.Status500InternalServerError, mensaje);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        void IRespuestaVoid.Ok(string mensaje)
        {
            _response = Ok(mensaje);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        void IRespuestaVoid.Error(string mensaje)
        {
            _response = StatusCode(StatusCodes.Status500InternalServerError, mensaje);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromServices] IClientesGetAll useCase)
        {
            if (ModelState.IsValid)
            {
                useCase.SetRespuesta(this);
                await useCase.GetAll();
                return _response!;
            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromBody] ClienteGetByIdDTO request, [FromServices] IClienteGetById useCase)
        {
            if (ModelState.IsValid)
            {
                useCase.SetRespuesta(this);
                await useCase.GetById(request.IdCliente);
                return _response!;
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> Search([FromBody] ClienteSearchDTO request, [FromServices] IBusquedaPorNombre useCase)
        {
            if (ModelState.IsValid)
            {
                useCase.SetRespuesta(this);
                await useCase.SearchByName(request.Nombre);
                return _response!;
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Cliente cliente, [FromServices] IClienteInsert useCase)
        {
            if (ModelState.IsValid)
            {
                useCase.SetRespuestaVoid(this);
                await useCase.Insert(cliente);
                return _response!;
            }
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Cliente cliente, [FromServices] IClienteUpdate useCase)
        {
            if (ModelState.IsValid)
            {
                useCase.SetRespuestaVoid(this);
                await useCase.Update(cliente);
                return _response!;
            }
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] ClienteDeleteDTO request, [FromServices] IClienteDelete useCase)
        {
            if (ModelState.IsValid)
            {
                useCase.SetRespuestaVoid(this);
                await useCase.Delete(request.IdCliente);
                return _response!;
            }
            else
                return BadRequest();
        }
    }
}
