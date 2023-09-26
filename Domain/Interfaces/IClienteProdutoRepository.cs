using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteProdutoRepository
    {
        Task AddAsync(ClienteProduto clienteProduto);
        void Add(ClienteProduto clienteProduto);
        Task Update(ClienteProduto clienteProduto);
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
