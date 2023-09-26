using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repositories
{
    public class ClienteProdutoRepository : IClienteProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClienteProduto entity)
        {
            await _context.AddAsync(entity);
        }

        public void Add(ClienteProduto entity)
        {
            _context.Add(entity);
        }

        public async Task Update(ClienteProduto entity)
        {
            _context.ClienteProduto.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
