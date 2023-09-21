using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Domain.Entities;

namespace Nurses_Scale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermeirosController : ControllerBase
    {
        private readonly IEnfermeiroService _enfermeiroService;

        public EnfermeirosController(IEnfermeiroService enfermeiroService)
        {
            _enfermeiroService = enfermeiroService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var enfermeiros = _enfermeiroService.ObterTodosEnfermeiros();
                return Ok(enfermeiros);
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
                var enfermeiro = _enfermeiroService.ObterEnfermeiroPorId(id);
                if (enfermeiro == null)
                    return NotFound();

                return Ok(enfermeiro);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Enfermeiro enfermeiro)
        {
            try
            {
                _enfermeiroService.CriarEnfermeiro(enfermeiro);
                return CreatedAtAction(nameof(Get), new { id = enfermeiro.EnfermeiroId }, enfermeiro);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Enfermeiro enfermeiro)
        {
            try
            {
                enfermeiro.EnfermeiroId = id;
                _enfermeiroService.AtualizarEnfermeiro(enfermeiro);
                return Ok(enfermeiro);
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
                _enfermeiroService.DeletarEnfermeiro(id);
                return Ok("Enfermeiro deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
