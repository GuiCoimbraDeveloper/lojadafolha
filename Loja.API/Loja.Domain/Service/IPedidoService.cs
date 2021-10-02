using Loja.Domain.Entites;
using Loja.Domain.Entites.Request.Pedido;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Service
{
    public interface IPedidoService
    {
        Task Add(AddPedido entity);

        Task Remove(int id);

        Task<Pedido> GetById(int id);

        Task<ICollection<Pedido>> GetAll();
    }
}
