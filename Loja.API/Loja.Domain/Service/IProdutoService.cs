using Loja.Domain.Entites;
using Loja.Domain.Entites.Request.Produto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Service
{
    public interface IProdutoService
    {
        Task Add(AddProduto entity);

        Task Remove(int id);

        Task<Produto> GetById(int id);

        Task<ICollection<Produto>> GetAll();
    }
}
