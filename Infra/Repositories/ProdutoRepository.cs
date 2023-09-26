using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Produto entity)
        {
            await _context.AddAsync(entity);
        }

        public void Add(Produto entity)
        {
            _context.AddAsync(entity);
        }

        public async Task Update(Produto entity)
        {
            _context.Produto.Update(entity);
        }

        public async Task<bool> DeleteById(int Id)
        {
            var pessoa = await _context.Produto.FindAsync(Id);
            if (pessoa != null)
            {
                _context.Produto.Remove(pessoa);
                await _context.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
