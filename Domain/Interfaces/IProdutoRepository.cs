using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task AddAsync(Produto produto);
        Task Update(Produto produto);
        Task<bool> DeleteById(int Id);
        Task SaveChangesAsync();
        void Add(Produto novoProduto);
    }
}
