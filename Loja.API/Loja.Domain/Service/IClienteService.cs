using Loja.Domain.Entites;
using Loja.Domain.Entites.Request.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Service
{
    public interface IClienteService
    {
        Task Add(AddCliente entity);

        Task Remove(int id);

        Task<Cliente> GetById(int id);

        Task<ICollection<Cliente>> GetAll();
    }
}
