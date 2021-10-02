using Loja.API.Controllers;
using Loja.Domain.Service;
using Loja.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Loja.API.TesteUnitario.Produto
{
    public class ProdutoControllerTeste
    {
        [Fact]
        public async Task AdicionarProduto_ChamadoPeloFront_RetornaOk()
        {
            //Padrão AAA

            /* Arrange
             * São realizados os preparativos para a ação e
             * resultado a serem testados.
             * Inicializações, alterações de estado
             * e definições de Mocks 
             */
            var serviceStub = new Mock<IProdutoService>();

            var produto = new Domain.Entites.Produto
            {
                Id = 1,
                Foto = "",
                Valor = 18.9m
            };

            var _controller = new ProdutoController(serviceStub.Object);

            /* Act 
             *  A parte mais simples. 
             *  Simplesmente chame o método a ser testado, 
             *  e armazene seu valor (ou não, se for um método sem retorno)
             */
            var result = await _controller.Add(produto);

            /* Assert
             * Verificações são feitas nessa etapa,
             * se constituindo concretamente nos parâmetros
             * de aprovação de um teste unitário.
             */
            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        public async Task BuscarTodosProduto_ChamadoPeloFront_RetornaLista()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
               //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .UseInMemoryDatabase(databaseName: "Loja")
               .Options;

            using var context = new DbDataContext(options);
            context.Produtos.Add(new Domain.Entites.Produto
            {
                Id = 1,
                Foto = "",
                Valor = 18.9m
            });
            await context.SaveChangesAsync();

            var serviceStub = new Mock<IProdutoService>();
            var _controller = new ProdutoController(serviceStub.Object);
            var result = await _controller.GetAll();

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        //[InlineData(1)]
        public async Task BuscarProdutoPeloId_ChamadoPeloFront_RetornaProduto()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
                   //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .UseInMemoryDatabase(databaseName: "Loja")
                   .Options;

            using var context = new DbDataContext(options);
            context.Produtos.Add(new Domain.Entites.Produto
            {
                Id = 1,
                Foto = "",
                Valor = 18.9m
            });
            await context.SaveChangesAsync();

            var serviceStub = new Mock<IProdutoService>();
            var _controller = new ProdutoController(serviceStub.Object);
            var result = await _controller.GetById(1);

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        public async Task DeletarProdutoPeloId_ChamadoPeloFront_RetornaOk()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
                       //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                       .UseInMemoryDatabase(databaseName: "Loja")
                       .Options;

            using var context = new DbDataContext(options);
            context.Produtos.Add(new Domain.Entites.Produto
            {
                Id = 1,
                Foto = "",
                Valor = 18.9m
            });
            await context.SaveChangesAsync();

            var serviceStub = new Mock<IProdutoService>();
            var _controller = new ProdutoController(serviceStub.Object);
            var result = await _controller.Remove(1);

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }
    }
}
