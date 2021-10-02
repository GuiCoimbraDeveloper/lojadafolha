using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task Add(T entity);

        Task Remove(int id);

        Task<T> GetById(int id);

        Task<ICollection<T>> GetAll();
    }
}
