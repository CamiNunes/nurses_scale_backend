using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Services
{
    public class DadosPagamentoService : IDadosPagamentoService
    {
        private readonly IDadosPagamentoRepository _dadosPagamentoRepository;

        public DadosPagamentoService(IDadosPagamentoRepository dadosPagamentoRepository)
        {
            _dadosPagamentoRepository = dadosPagamentoRepository;
        }

        public async Task<IEnumerable<DadosPagamento>> ObterTodosDadosPagamentos()
        {
            return await _dadosPagamentoRepository.ObterTodosAsync();
        }

        public async Task<DadosPagamento> ObterDadosPagamentoPorId(Guid id)
        {
            return await _dadosPagamentoRepository.ObterPorIdAsync(id);
        }

        public async Task CriarDadosPagamento(DadosPagamento dadosPagamento)
        {
            await _dadosPagamentoRepository.InserirAsync(dadosPagamento);
        }

        public async Task AtualizarDadosPagamento(DadosPagamento dadosPagamento)
        {
            await _dadosPagamentoRepository.AtualizarAsync(dadosPagamento);
        }

        public async Task DeletarDadosPagamento(Guid id)
        {
            await _dadosPagamentoRepository.ExcluirAsync(id);
        }
    }
}
