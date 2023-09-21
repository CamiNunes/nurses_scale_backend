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
    public class EnfermeiroService : IEnfermeiroService
    {
        private readonly IEnfermeiroRepository _enfermeiroRepository;
        private readonly IDadosPagamentoRepository _dadosPagamentoRepository;

        public EnfermeiroService(IEnfermeiroRepository enfermeiroRepository)
        {
            _enfermeiroRepository = enfermeiroRepository;
        }

        public async Task<IEnumerable<Enfermeiro>> ObterTodosEnfermeiros()
        {
            return await _enfermeiroRepository.ObterTodosAsync();
        }

        public async Task<Enfermeiro> ObterEnfermeiroPorId(Guid id)
        {
            return await _enfermeiroRepository.ObterPorIdAsync(id);
        }

        public async Task CriarEnfermeiro(Enfermeiro enfermeiro)
        {
            await _enfermeiroRepository.InserirAsync(enfermeiro);
        }

        public async Task AtualizarEnfermeiro(Enfermeiro enfermeiro)
        {
            await _enfermeiroRepository.AtualizarAsync(enfermeiro);
        }

        public async Task DeletarEnfermeiro(Guid id)
        {
            await _enfermeiroRepository.ExcluirAsync(id);
        }
    }
}
