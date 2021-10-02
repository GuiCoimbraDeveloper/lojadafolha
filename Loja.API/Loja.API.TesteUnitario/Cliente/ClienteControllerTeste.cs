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

namespace Loja.API.TesteUnitario.Cliente
{
    public class ClienteControllerTeste
    {
        [Fact]
        public async Task AdicionarCliente_ChamadoPeloFront_RetornaOk()
        {
            //Padrão AAA

            /* Arrange
             * São realizados os preparativos para a ação e
             * resultado a serem testados.
             * Inicializações, alterações de estado
             * e definições de Mocks 
             */
            var cardRequestServiceStub = new Mock<IClienteService>();

            var cliente = new Domain.Entites.Cliente
            {
                Id = 0,
                Aldeia = "Alguma",
                Email = "teste@teste.com.br",
                Nome = "Guilherme"
            };
            //cardRequestServiceStub.Setup(service =>
            //   service.Add(cliente)
            //   ).ReturnsAsync(void);

            var _controller = new ClienteController(cardRequestServiceStub.Object);

            /* Act 
             *  A parte mais simples. 
             *  Simplesmente chame o método a ser testado, 
             *  e armazene seu valor (ou não, se for um método sem retorno)
             */
            var result = await _controller.Add(cliente);

            /* Assert
             * Verificações são feitas nessa etapa,
             * se constituindo concretamente nos parâmetros
             * de aprovação de um teste unitário.
             */
            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        public async Task BuscarTodosClientes_ChamadoPeloFront_RetornaLista()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
               //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .UseInMemoryDatabase(databaseName: "Loja")
               .Options;

            using var context = new DbDataContext(options);
            context.Clientes.Add(new Domain.Entites.Cliente
            {
                Id = 0,
                Aldeia = "Alguma",
                Email = "teste@teste.com.br",
                Nome = "Guilherme"
            });
            await context.SaveChangesAsync();

            var cardRequestServiceStub = new Mock<IClienteService>();
            var _controller = new ClienteController(cardRequestServiceStub.Object);
            var result = await _controller.GetAll();

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        [InlineData(1)]
        public async Task BuscarClientepeloId_ChamadoPeloFront_RetornaCliente()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
                   //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .UseInMemoryDatabase(databaseName: "Loja")
                   .Options;

            using var context = new DbDataContext(options);
            context.Clientes.Add(new Domain.Entites.Cliente
            {
                Id = 1,
                Aldeia = "Alguma",
                Email = "teste@teste.com.br",
                Nome = "Guilherme"
            });
            await context.SaveChangesAsync();

            var cardRequestServiceStub = new Mock<IClienteService>();
            var _controller = new ClienteController(cardRequestServiceStub.Object);
            var result = await _controller.GetById(1);

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }

        [Fact]
        public async Task DeletarClientePeloId_ChamadoPeloFront_RetornaOk()
        {
            var options = new DbContextOptionsBuilder<DbDataContext>()
                       //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                       .UseInMemoryDatabase(databaseName: "Loja")
                       .Options;

            using var context = new DbDataContext(options);
            context.Clientes.Add(new Domain.Entites.Cliente
            {
                Id = 1,
                Aldeia = "Alguma",
                Email = "teste@teste.com.br",
                Nome = "Guilherme"
            });
            await context.SaveChangesAsync();

            var cardRequestServiceStub = new Mock<IClienteService>();
            var _controller = new ClienteController(cardRequestServiceStub.Object);
            var result = await _controller.Remove(1);

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
        }
    }
}
