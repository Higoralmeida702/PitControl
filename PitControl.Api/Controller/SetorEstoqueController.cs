using Microsoft.AspNetCore.Mvc;
using PitControl.Application.Dto;
using PitControl.Application.Interfaces;
using PitControl.Domain.Model;

namespace PitControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetorEstoqueController : ControllerBase
    {
        private readonly ISetorEstoqueService _service;
        public SetorEstoqueController(ISetorEstoqueService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarNovoEstoque([FromBody] SetorEstoqueDto setorEstoqueDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.AddSetorEstoque(setorEstoqueDto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEstoque(SetorEstoqueDto setorEstoqueDto, int id)
        {
            if (setorEstoqueDto == null)
                return BadRequest("Dados inválidos.");

            var estoque = await _service.UpdateSetorEstoque(setorEstoqueDto, id);

            if (!estoque.Status)
                return NotFound(estoque.Mensagem);

            return Ok(estoque);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estoque = await _service.GetAll();
            return Ok(estoque);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estoque = await _service.GetById(id);

            if (!estoque.Status)
                return NotFound(estoque.Mensagem);

            return Ok(estoque);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estoque = await _service.DeleteSetorEstoque(id);

            if (!estoque.Status)
                return NotFound(estoque.Mensagem);

            return Ok(estoque);
        }
    }
}
