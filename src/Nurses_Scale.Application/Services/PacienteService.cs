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
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> ObterTodosPacientes()
        {
            return await _pacienteRepository.ObterTodosAsync();
        }

        public async Task<Paciente> ObterPacientePorId(Guid id)
        {
            return await _pacienteRepository.ObterPorIdAsync(id);
        }

        public async Task CriarPaciente(Paciente paciente)
        {
            await _pacienteRepository.InserirAsync(paciente);
        }

        public async Task AtualizarPaciente(Paciente paciente)
        {
            await _pacienteRepository.AtualizarAsync(paciente);
        }

        public async Task DeletarPaciente(Guid id)
        {
            await _pacienteRepository.ExcluirAsync(id);
        }
    }
}
