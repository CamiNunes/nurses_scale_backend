using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Interfaces.Repositories
{
    public interface IDadosPagamentoRepository
    {
        Task<IEnumerable<DadosPagamento>> ObterTodosAsync();
        Task<DadosPagamento> ObterPorIdAsync(Guid id);
        Task InserirAsync(DadosPagamento dadosPagamento);
        Task AtualizarAsync(DadosPagamento dadosPagamento);
        Task ExcluirAsync(Guid id);
    }
}
