using Loja.Domain.Entites;
using Loja.Domain.Entites.Request.Produto;
using Loja.Domain.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Loja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Retorna uma lista com os favorecidos do usuario
        /// </summary>
        /// <param name="teanantId">Identificador da trinus</param>
        /// <response code="200">Lista com favorecidos.</response>
        /// <response code="401">Não autorizado.</response>
        [HttpPost]
        public async Task<IActionResult> Add(AddProduto entity)
        {
            try
            {
                await _produtoService.Add(entity);
                return Ok("Salvo com sucesso");
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }

        }

        /// <summary>
        /// Retorna uma lista com os favorecidos do usuario
        /// </summary>
        /// <param name="teanantId">Identificador da trinus</param>
        /// <response code="200">Lista com favorecidos.</response>
        /// <response code="500">Problema no servidor.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _produtoService.GetAll());
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }

        }

        /// <summary>
        /// Retorna uma lista com os favorecidos do usuario
        /// </summary>
        /// <param name="teanantId">Identificador da trinus</param>
        /// <param name="deviceId">Identificador do celular/dispositivo do usuario.</param>
        /// <response code="200">Lista com favorecidos.</response>
        /// <response code="500">Problema no servidor.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _produtoService.GetById(id));
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista com os favorecidos do usuario
        /// </summary>
        /// <param name="teanantId">Identificador da trinus</param>
        /// <response code="200">Lista com favorecidos.</response>
        /// <response code="500">Problema no servidor.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _produtoService.Remove(id);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception er)
            {
                return StatusCode(500, er.Message);
            }
        }

    }
}
