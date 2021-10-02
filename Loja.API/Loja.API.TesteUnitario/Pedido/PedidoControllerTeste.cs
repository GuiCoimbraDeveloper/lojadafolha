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

namespace Loja.API.TesteUnitario.Pedido
{
    public class PedidoControllerTeste
    {
        [Fact]
        public async Task AdicionarPedido_ChamadoPeloFront_RetornaOk()
        {
            //Padrão AAA

            /* Arrange
             * São realizados os preparativos para a ação e
             * resultado a serem testados.
             * Inicializações, alterações de estado
             * e definições de Mocks 
             */
            var serviceStub = new Mock<IPedidoService>();

            var pedido = new Domain.Entites.Pedido
            {
                Id = 1,
                Data = DateTime.Now,
                Desconto = null,
                Numero = 123,
                Valor = 25.90m,
                ValorTotal = 25.90m,
                PedidoItens = new List<Domain.Entites.PedidoItens>() { new Domain.Entites.PedidoItens { Id = 1, PedidoId = 1, ProdutoId = 2 } }
            };

            //serviceStub.Setup(service =>
            //   service.Add(cliente)
            //   ).ReturnsAsync(void);

            var _controller = new PedidoController(serviceStub.Object);

            /* Act 
             *  A parte mais simples. 
             *  Simplesmente chame o método a ser testado, 
             *  e armazene seu valor (ou não, se for um método sem retorno)
             */
            var result = await _controller.Add(pedido);

            /* Assert
             * Verificações são feitas nessa etapa,
             * se constituindo concretamente nos parâmetros
             * de aprovação de um teste unitário.
             */
            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        public async Task BuscarTodosPedidos_ChamadoPeloFront_RetornaLista()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
               //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .UseInMemoryDatabase(databaseName: "Loja")
               .Options;

            using var context = new DbDataContext(options);
            context.Pedidos.Add(new Domain.Entites.Pedido
            {
                Id = 1,
                Data = DateTime.Now,
                Desconto = null,
                Numero = 123,
                Valor = 25.90m,
                ValorTotal = 25.90m,
                PedidoItens = new List<Domain.Entites.PedidoItens>() { new Domain.Entites.PedidoItens { Id = 1, PedidoId = 1, ProdutoId = 2 } }
            });
            await context.SaveChangesAsync();

            var serviceStub = new Mock<IPedidoService>();
            var _controller = new PedidoController(serviceStub.Object);
            var result = await _controller.GetAll();

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        //[InlineData(1)]
        public async Task BuscarPedidoPeloId_ChamadoPeloFront_RetornaPedido()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
                   //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .UseInMemoryDatabase(databaseName: "Loja")
                   .Options;

            using var context = new DbDataContext(options);
            context.Pedidos.Add(new Domain.Entites.Pedido
            {
                Id = 1,
                Data = DateTime.Now,
                Desconto = null,
                Numero = 123,
                Valor = 25.90m,
                ValorTotal = 25.90m,
                PedidoItens = new List<Domain.Entites.PedidoItens>() { new Domain.Entites.PedidoItens { Id = 1, PedidoId = 1, ProdutoId = 2 } }
            });
            await context.SaveChangesAsync();

            var serviceStub = new Mock<IPedidoService>();
            var _controller = new PedidoController(serviceStub.Object);
            var result = await _controller.GetById(1);

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        public async Task DeletarPedidoPeloId_ChamadoPeloFront_RetornaOk()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
                       //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                       .UseInMemoryDatabase(databaseName: "Loja")
                       .Options;

            using var context = new DbDataContext(options);
            context.Pedidos.Add(new Domain.Entites.Pedido
            {
                Id = 1,
                Data = DateTime.Now,
                Desconto = null,
                Numero = 123,
                Valor = 25.90m,
                ValorTotal = 25.90m,
                PedidoItens = new List<Domain.Entites.PedidoItens>() { new Domain.Entites.PedidoItens { Id = 1, PedidoId = 1, ProdutoId = 2 } }
            });
            await context.SaveChangesAsync();

            var serviceStub = new Mock<IPedidoService>();
            var _controller = new PedidoController(serviceStub.Object);
            var result = await _controller.Remove(1);

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }
    }
}
