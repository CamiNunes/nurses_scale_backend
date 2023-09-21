using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> ObterTodosPacientes();
        Task<Paciente> ObterPacientePorId(Guid id);
        Task CriarPaciente(Paciente paciente);
        Task AtualizarPaciente(Paciente paciente);
        Task DeletarPaciente(Guid id);
    }
}
