using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Interfaces
{
    public interface IEnfermeiroService
    {
        Task<IEnumerable<Enfermeiro>> ObterTodosEnfermeiros();
        Task<Enfermeiro> ObterEnfermeiroPorId(Guid id);
        Task CriarEnfermeiro(Enfermeiro enfermeiro);
        Task AtualizarEnfermeiro(Enfermeiro enfermeiro);
        Task DeletarEnfermeiro(Guid id);
    }
}
