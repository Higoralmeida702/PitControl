using Microsoft.AspNetCore.Mvc;
using PitControl.Application.Dto;
using PitControl.Application.Interfaces;
using PitControl.Domain.Model;

namespace PitControl.Api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.AddProduto(produtoDto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] ProdutoDto produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Dados inválidos.");

            var produto = await _service.UpdateProduto(id, produtoDto);

            if (!produto.Sucesso)
                return NotFound(produto.Mensagem);

            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _service.GetAll();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _service.GetById(id);

            if (!produto.Status == true)
                return NotFound(produto.Mensagem);

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _service.DeleteProduto(id);

            if (!!produto.Status == true)
                return NotFound(produto.Mensagem);

            return Ok(produto);
        }
    }
}
