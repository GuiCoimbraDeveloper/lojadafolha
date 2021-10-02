using Loja.Domain.Entites;
using Loja.Domain.Entites.Request.Cliente;
using Loja.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Loja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Adiciona ou Atualiza um cliente
        /// </summary>
        /// <param name="entity">Objeto Cliente</param>
        /// <response code="200">Salvo com sucesso.</response>
        /// <response code="500">Houve Erro na hora de salvar.</response>
        [HttpPost]
        public async Task<IActionResult> Add(AddCliente entity)
        {
            try
            {
                await _clienteService.Add(entity);
                return Ok("Salvo com sucesso");
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }

        }

        /// <summary>
        /// Retorna uma lista com os Clientes
        /// </summary>
        /// <response code="200">Lista com clientes.</response>
        /// <response code="500">Problema ao retornar a lista.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _clienteService.GetAll());
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }

        }

        /// <summary>
        /// Retorna um cliente  especifico buscando pelo id
        /// </summary>
        /// <param name="id">Codigo do cliente</param>
        /// <response code="200">Retorna um cliente.</response>
        /// <response code="500">Problema ao retornar cliente.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _clienteService.GetById(id));
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="id">Codigo do cliente</param>
        /// <response code="200">Cliente Deletado.</response>
        /// <response code="500">Problema ao deletar cliente.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _clienteService.Remove(id);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }
        }
    }
}
