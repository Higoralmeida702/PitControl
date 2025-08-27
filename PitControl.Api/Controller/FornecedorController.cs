using Microsoft.AspNetCore.Mvc;
using PitControl.Application.Dto;
using PitControl.Application.Interfaces;
using PitControl.Domain.Model;
using PitControl.Application.Common;

namespace PitControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _service;

        public FornecedorController(IFornecedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Resposta<List<Fornecedor>>>> GetAll()
        {
            var resposta = await _service.GetAll();
            return Ok(resposta);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resposta<Fornecedor>>> GetById(int id)
        {
            var resposta = await _service.GetById(id);
            if (!resposta.Status)
                return NotFound(resposta);

            return Ok(resposta);
        }

        [HttpPost]
        public async Task<ActionResult<Resposta<Fornecedor>>> AddFornecedor([FromBody] FornecedorDto fornecedorDto)
        {
            var resposta = await _service.AddFornecedor(fornecedorDto);
            return CreatedAtAction(nameof(GetById), new { id = resposta.Dados?.Id }, resposta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Resposta<Fornecedor>>> UpdateFornecedor(int id, [FromBody] FornecedorDto fornecedorDto)
        {
            var resposta = await _service.UpdateFornecedor(id, fornecedorDto);
            if (!resposta.Status)
                return NotFound(resposta);

            return Ok(resposta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Resposta<Fornecedor>>> DeleteFornecedor(int id)
        {
            var resposta = await _service.DeleteFornecedor(id);
            if (!resposta.Status)
                return NotFound(resposta);

            return Ok(resposta);
        }
    }
}
