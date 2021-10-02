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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbDataContext _dbDataContext;
        public ProdutoRepository(DbDataContext dbDataContext)
        {
            _dbDataContext = dbDataContext;
        }

        public async Task Add(Produto entity)
        {
            if (entity.Id == 0)
                _dbDataContext.Produtos.Add(entity);
            else
            {
                var aux = await _dbDataContext.Produtos.FirstOrDefaultAsync(item => item.DeletedAt == null && item.Id == entity.Id);

                if (aux == null)
                    throw new Exception("Produto não encontrado para atualizar");

                aux.Descricao = entity.Descricao;
                aux.Valor = entity.Valor;
                aux.Foto = entity.Foto;
                aux.AlteredAt = DateTime.Now;
            }
            await _dbDataContext.SaveChangesAsync();
        }

        public async Task<ICollection<Produto>> GetAll()
        {
            return await _dbDataContext.Produtos.Where(item => item.DeletedAt == null).ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            var item = await _dbDataContext.Produtos.Where(item => item.DeletedAt == null && item.Id == id).FirstOrDefaultAsync();
            if (item == null)
                throw new Exception("Produto não encontrado");

            return item;
        }

        public async Task Remove(int id)
        {
            var aux = await _dbDataContext.Produtos.FirstOrDefaultAsync(item => item.DeletedAt == null && item.Id == id);

            if (aux == null)
                throw new Exception("Produto não encontrado para deletar");

            aux.DeletedAt = DateTime.Now;

            await _dbDataContext.SaveChangesAsync();
        }
    }
}
