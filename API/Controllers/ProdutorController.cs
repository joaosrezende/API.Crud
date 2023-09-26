using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] AddProdutoDto addProdutoDto)
        {
            try
            {
                bool resultado = await _produtoService.Add(addProdutoDto);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProdutoDto produtoDto)
        {
            await _produtoService.Update(produtoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _produtoService.Delete(id);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        [HttpGet("get-pagination")]
        public async Task<ActionResult> GetPagination([FromQuery] PaginationRequest paginationRequest)
        {
            var responseService = await _produtoService.GetFilter(paginationRequest);
            return Ok(responseService);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var responseService = await _produtoService.Get();
            return Ok(responseService);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var produto = await _produtoService.GetById(id);
            return Ok(produto);
        }
        
    }
}
