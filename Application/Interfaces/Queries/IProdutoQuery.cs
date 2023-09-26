using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Queries
{
    public interface IProdutoQuery
    {
        Task<List<Produto>> Get();
        Task<PaginationResponse<ProdutoDto>> GetFilter(PaginationRequest paginationRequest);
        Task<ProdutoDto> GetById(int id);
    }
}
