using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Domain.Entities;

namespace Nurses_Scale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var enderecos = _enderecoService.ObterTodosEnderecos(id);
                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpGet("{id}/{enderecoId}")]
        public IActionResult Get(Guid id, Guid enderecoId)
        {
            try
            {
                var endereco = _enderecoService.ObterEnderecoPorId(id, enderecoId);
                if (endereco == null)
                    return NotFound();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            try
            {
                _enderecoService.CriarEndereco(endereco);
                return CreatedAtAction(nameof(Get), new { id = endereco.EnderecoId }, endereco);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut("{id}/{enderecoId}")]
        public IActionResult Put(Guid id, Guid enderecoId, [FromBody] Endereco endereco)
        {
            try
            {
                endereco.PacienteId = id;
                endereco.EnderecoId = enderecoId;
                _enderecoService.AtualizarEndereco(endereco);
                return Ok("Endereço atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpDelete("{id}/{enderecoId}")]
        public IActionResult Delete(Guid id, Guid enderecoId)
        {
            try
            {
                _enderecoService.DeletarEndereco(id, enderecoId);
                return Ok("Endereço deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
