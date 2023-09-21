using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Interfaces
{
    public interface IAtendimentoService
    {
        Task<IEnumerable<Atendimento>> ObterTodosAtendimentos();
        Task<Atendimento> ObterAtendimentoPorId(Guid id);
        Task CriarAtendimento(Atendimento atendimento);
        Task AtualizarAtendimento(Atendimento atendimento);
        Task DeletarAtendimento(Guid id);
    }
}
