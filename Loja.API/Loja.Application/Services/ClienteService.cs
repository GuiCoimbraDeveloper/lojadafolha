using Loja.Domain.Entites;
using Loja.Domain.Entites.Request.Cliente;
using Loja.Domain.Repositories;
using Loja.Domain.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task Add(AddCliente entity)
        {
            var model = new Cliente
            {
                Id = entity.Id,
                Aldeia = entity.Aldeia,
                Email = entity.Email,
                Nome = entity.Nome
            };

            await _clienteRepository.Add(model);
        }

        public async Task<ICollection<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Remove(int id)
        {
            await _clienteRepository.Remove(id);
        }
    }
}
