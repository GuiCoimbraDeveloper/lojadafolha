using Loja.Domain.Entites;
using Loja.Domain.Repositories;
using Loja.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Infra.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DbDataContext _dbDataContext;
        public PedidoRepository(DbDataContext dbDataContext)
        {
            _dbDataContext = dbDataContext;
        }

        public async Task Add(Pedido entity)
        {
            if (entity.Id == 0)
            {
                _dbDataContext.Pedidos.Attach(entity);
            }
            else
            {
                var aux = await _dbDataContext.Pedidos.FirstOrDefaultAsync(item => item.DeletedAt == null && item.Id == entity.Id);

                if (aux == null)
                    throw new Exception("Pedido não encontrado para atualizar");

                aux.Numero = entity.Numero;
                aux.Data = entity.Data;
                aux.ClienteId = entity.ClienteId;
                aux.Valor = entity.Valor;
                aux.Desconto = entity.Desconto;
                aux.ValorTotal = entity.ValorTotal;
                aux.AlteredAt = DateTime.Now;
            }
            await _dbDataContext.SaveChangesAsync();
        }

        public async Task<ICollection<Pedido>> GetAll()
        {
            return await _dbDataContext.Pedidos.Include(x => x.PedidoItens).Where(item => item.DeletedAt == null).ToListAsync();
        }

        public async Task<Pedido> GetById(int id)
        {
            var item = await _dbDataContext.Pedidos.Include(x => x.PedidoItens).Where(item => item.DeletedAt == null && item.Id == id).FirstOrDefaultAsync();
            if (item == null)
                throw new Exception("Pedido não encontrado");

            return item;
        }

        public async Task Remove(int id)
        {
            var aux = await _dbDataContext.Pedidos.FirstOrDefaultAsync(item => item.DeletedAt == null && item.Id == id);

            if (aux == null)
                throw new Exception("Pedido não encontrado para deletar");

            aux.DeletedAt = DateTime.Now;

            await _dbDataContext.SaveChangesAsync();
        }
    }
}
