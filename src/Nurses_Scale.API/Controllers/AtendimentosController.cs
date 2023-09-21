using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Application.Services;
using Nurses_Scale.Domain.Entities;

namespace Nurses_Scale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentosController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var atendimentos = _atendimentoService.ObterTodosAtendimentos();
                return Ok(atendimentos);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }   
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var atendimento = _atendimentoService.ObterAtendimentoPorId(id);
                if (atendimento == null)
                    return NotFound();

                return Ok(atendimento);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] Atendimento atendimento)
        {
            try
            {
                _atendimentoService.CriarAtendimento(atendimento);
                return CreatedAtAction(nameof(Get), new { id = atendimento.AtendimentoId }, atendimento);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Atendimento atendimento)
        {
            try
            {
                atendimento.AtendimentoId = id;
                _atendimentoService.AtualizarAtendimento(atendimento);
                return Ok(atendimento);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _atendimentoService.DeletarAtendimento(id);
                return Ok("Atendimento deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
