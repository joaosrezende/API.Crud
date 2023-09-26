using Application.DTOs;
using Application.Interfaces.Queries;
using Domain.Entities;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Queries
{
    public class ProdutoQuery : IProdutoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ProdutoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Produto?>?> Get()
        {
            var produto = _dbContext.Produto.AsNoTracking().ToList();

            if (produto == null)
                return null;

            return produto;
        }

        public async Task<PaginationResponse<ProdutoDto>> GetFilter(PaginationRequest paginationRequest)
        {
            var query = _dbContext.Produto.AsNoTracking();

            var paginatedQuery = query
                .Select(c => new ProdutoDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Preco = c.Preco
                })
                .Skip((paginationRequest.PageNumber - 1) * paginationRequest.PageSize) 
                .Take(paginationRequest.PageSize); 

            var data = await paginatedQuery.ToListAsync();

            var totalCount = await query.CountAsync(); 

            var paginationResponse = new PaginationResponse<ProdutoDto>
            {
                PageNumber = paginationRequest.PageNumber,
                PageSize = paginationRequest.PageSize,
                TotalItems = totalCount, 
                Data = data,
            };

            return paginationResponse;
        }

        public async Task<ProdutoDto?> GetById(int id)
        {
            var produto = await _dbContext.Produto
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (produto == null)
                return null;

            var produtoDto = new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };

            return produtoDto;
        }
    }
}
