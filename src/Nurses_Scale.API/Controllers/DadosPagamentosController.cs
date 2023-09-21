using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Application.Services;
using Nurses_Scale.Domain.Entities;

namespace Nurses_Scale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosPagamentosController : ControllerBase
    {
        private readonly IDadosPagamentoService _dadosPagamentosService;

        public DadosPagamentosController(IDadosPagamentoService dadosPagamentosService)
        {
            _dadosPagamentosService = dadosPagamentosService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dadosPagamentos = _dadosPagamentosService.ObterTodosDadosPagamentos();
                return Ok(dadosPagamentos);
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
                var dadosPagamento = _dadosPagamentosService.ObterDadosPagamentoPorId(id);
                if (dadosPagamento == null)
                    return NotFound();

                return Ok(dadosPagamento);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] DadosPagamento dadosPagamento)
        {
            try
            {
                _dadosPagamentosService.CriarDadosPagamento(dadosPagamento);
                return CreatedAtAction(nameof(Get), new { id = Guid.NewGuid() }, dadosPagamento);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] DadosPagamento dadosPagamento)
        {
            try
            {
                dadosPagamento.DadosPagamentoId = id;
                _dadosPagamentosService.AtualizarDadosPagamento(dadosPagamento);
                return Ok(dadosPagamento);
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
                _dadosPagamentosService.DeletarDadosPagamento(id);
                return Ok("Dados Pagamento deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
