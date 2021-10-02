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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbDataContext _dbDataContext;
        public ClienteRepository(DbDataContext dbDataContext)
        {
            _dbDataContext = dbDataContext;
        }

        public async Task Add(Cliente entity)
        {
            if (entity.Id == 0)
                _dbDataContext.Clientes.Add(entity);
            else
            {
                var aux = await _dbDataContext.Clientes.FirstOrDefaultAsync(item => item.DeletedAt == null && item.Id == entity.Id);

                if (aux == null)
                    throw new Exception("Cliente não encontrado para atualizar");

                aux.Nome = entity.Nome;
                aux.Email = entity.Email;
                aux.Aldeia = entity.Aldeia;
                aux.AlteredAt = DateTime.Now;
            }
            await _dbDataContext.SaveChangesAsync();
        }

        public async Task<ICollection<Cliente>> GetAll()
        {
            return await _dbDataContext.Clientes.Where(item => item.DeletedAt == null).ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            var item = await _dbDataContext.Clientes.Where(item => item.DeletedAt == null && item.Id == id).FirstOrDefaultAsync();
            if (item == null)
                throw new Exception("Cliente não encontrado");

            return item;
        }

        public async Task Remove(int id)
        {
            var aux = await _dbDataContext.Clientes.FirstOrDefaultAsync(item => item.DeletedAt == null && item.Id == id);

            if (aux == null)
                throw new Exception("Cliente não encontrado para deletar");

            aux.DeletedAt = DateTime.Now;

            await _dbDataContext.SaveChangesAsync();
        }
    }
}
