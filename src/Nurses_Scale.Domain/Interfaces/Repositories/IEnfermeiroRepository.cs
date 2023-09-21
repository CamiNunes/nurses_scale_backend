using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Interfaces.Repositories
{
    public interface IEnfermeiroRepository
    {
        Task<IEnumerable<Enfermeiro>> ObterTodosAsync();
        Task<Enfermeiro> ObterPorIdAsync(Guid id);
        Task InserirAsync(Enfermeiro enfermeiro);
        Task AtualizarAsync(Enfermeiro enfermeiro);
        Task ExcluirAsync(Guid id);
    }
}
