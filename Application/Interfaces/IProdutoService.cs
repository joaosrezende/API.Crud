using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProdutoService
    {
        Task<bool> Add(AddProdutoDto addProdutoDto);
        Task Update(UpdateProdutoDto produtoDto);
        Task<bool> Delete(int id);
        Task<List<Produto>> Get();
        Task<PaginationResponse<ProdutoDto>> GetFilter(PaginationRequest paginationRequest);
        Task<ProdutoDto> GetById(int id);
    }
}
