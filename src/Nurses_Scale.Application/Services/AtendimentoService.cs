using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Interfaces.Repositories;
using Nurses_Scale.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;

        public AtendimentoService(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }

        public async Task<IEnumerable<Atendimento>> ObterTodosAtendimentos()
        {
            return await _atendimentoRepository.ObterTodosAsync();
        }

        public async Task<Atendimento> ObterAtendimentoPorId(Guid id)
        {
            return await _atendimentoRepository.ObterPorIdAsync(id);
        }

        public async Task CriarAtendimento(Atendimento atendimento)
        {
            await _atendimentoRepository.InserirAsync(atendimento);
        }

        public async Task AtualizarAtendimento(Atendimento atendimento)
        {
            await _atendimentoRepository.AtualizarAsync(atendimento);
        }

        public async Task DeletarAtendimento(Guid id)
        {
            await _atendimentoRepository.ExcluirAsync(id);
        }
    }
}
