using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> ObterTodosAsync();
        Task<Paciente> ObterPorIdAsync(Guid id);
        Task InserirAsync(Paciente paciente);
        Task AtualizarAsync(Paciente paciente);
        Task ExcluirAsync(Guid id);
    }
}
