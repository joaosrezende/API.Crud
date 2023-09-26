using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Queries;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoQuery _produtoQuery;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteProdutoRepository _clienteProdutoRepository;
        public ProdutoService(IProdutoQuery produtoQuery, IProdutoRepository produtoRepository, IClienteProdutoRepository clienteProdutoRepository) 
        {
            _produtoQuery = produtoQuery;
            _produtoRepository = produtoRepository;
            _clienteProdutoRepository = clienteProdutoRepository;
        }

        public async Task<bool> Add(AddProdutoDto addProdutoDto)
        {
            var novoProduto = new Produto(addProdutoDto.Nome, addProdutoDto.Preco);

            _produtoRepository.Add(novoProduto);
            await _produtoRepository.SaveChangesAsync();

            var clienteProduto = new ClienteProduto(addProdutoDto.IdCliente, novoProduto.Id);

            _clienteProdutoRepository.Add(clienteProduto);
            await _clienteProdutoRepository.SaveChangesAsync();

            return true;
        }

        public async Task Update(UpdateProdutoDto updateProdutoDto)
        {
            var produto = await _produtoQuery.GetById(updateProdutoDto.Id);

            if (produto == null)
                throw new ArgumentException("Produto não encontrado");

            var updateProduto = new Produto(updateProdutoDto.Id, updateProdutoDto.Nome, updateProdutoDto.Preco);

            await _produtoRepository.Update(updateProduto);
            await _produtoRepository.SaveChangesAsync();
        }

        public async Task<bool> Delete(int Id)
        {
            var retorno = await _produtoRepository.DeleteById(Id);
            await _produtoRepository.SaveChangesAsync();

            return retorno;
        }

        public async Task<List<Produto>> Get()
        {
            return await _produtoQuery.Get();
        }

        public async Task<PaginationResponse<ProdutoDto>> GetFilter(PaginationRequest paginationRequest)
        {
            return await _produtoQuery.GetFilter(paginationRequest);
        }

        public async Task<ProdutoDto> GetById(int id)
        {
            return await _produtoQuery.GetById(id);
        }
    }
}
