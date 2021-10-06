using Loja.Domain.Entites;
using Loja.Domain.Entites.Request.Pedido;
using Loja.Domain.Repositories;
using Loja.Domain.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task Add(AddPedido entity)
        {
            var aux = new Pedido
            {
                Id = entity.Id,
                Numero = 0,
                Data = entity.Data,
                Desconto = entity.Desconto,
                Valor = entity.Valor,
                ValorTotal = entity.ValorTotal,
                ClienteId = entity.ClienteId,
                PedidoItens = entity.PedidoItens.Select(item =>
                new PedidoItens
                {
                    Id = item.Id,
                    PedidoId = item.PedidoId,
                    ProdutoId = item.ProdutoId
                }).ToList()
            };
            await _pedidoRepository.Add(aux);
        }

        public async Task<ICollection<Pedido>> GetAll()
        {
            return await _pedidoRepository.GetAll();
        }

        public async Task<Pedido> GetById(int id)
        {
            return await _pedidoRepository.GetById(id);
        }

        public async Task Remove(int id)
        {
            await _pedidoRepository.Remove(id);
        }
    }
}
