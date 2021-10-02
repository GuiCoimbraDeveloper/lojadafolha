using Loja.Domain.Entites;
using Loja.Domain.Entites.Request.Pedido;
using Loja.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Loja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Adiciona ou Atualiza um pedido
        /// </summary>
        /// <param name="entity">Objeto pedido</param>
        /// <response code="200">Salvo com sucesso.</response>
        /// <response code="500">Houve Erro na hora de salvar.</response>
        [HttpPost]
        public async Task<IActionResult> Add(AddPedido entity)
        {
            try
            {
                await _pedidoService.Add(entity);
                return Ok("Salvo com sucesso");
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }

        }

        /// <summary>
        /// Retorna uma lista com os pedidos
        /// </summary>
        /// <response code="200">Lista com pedidos.</response>
        /// <response code="500">Problema ao retornar a lista.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _pedidoService.GetAll());
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }

        }

        /// <summary>
        /// Retorna um pedido especifico buscando pelo id
        /// </summary>
        /// <param name="id">Codigo do pedido</param>
        /// <response code="200">Retorna um pedido.</response>
        /// <response code="500">Problema ao retornar pedido.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _pedidoService.GetById(id));
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }
        }

        /// <summary>
        /// Deleta um Pedido
        /// </summary>
        /// <param name="id">Codigo do Pedido</param>
        /// <response code="200">Pedido Deletado.</response>
        /// <response code="500">Problema ao deletar Pedido.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _pedidoService.Remove(id);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }
        }
    }
}