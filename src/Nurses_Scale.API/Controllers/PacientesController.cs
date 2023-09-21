using Microsoft.AspNetCore.Mvc;
using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Domain.Entities;

namespace Nurses_Scale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pacientes = _pacienteService.ObterTodosPacientes();
                return Ok(pacientes);
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
                var paciente = _pacienteService.ObterPacientePorId(id);
                if (paciente == null)
                    return NotFound();

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Paciente paciente)
        {
            try
            {
                _pacienteService.CriarPaciente(paciente);
                return CreatedAtAction(nameof(Get), new { id = Guid.NewGuid() }, paciente);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Paciente paciente)
        {
            try
            {
                paciente.PacienteId = id;
                _pacienteService.AtualizarPaciente(paciente);
                return Ok(paciente);
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
                _pacienteService.DeletarPaciente(id);
                return Ok("Paciente deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
