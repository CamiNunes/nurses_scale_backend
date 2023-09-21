using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Interfaces
{
    public interface IDadosPagamentoService
    {
        Task<IEnumerable<DadosPagamento>> ObterTodosDadosPagamentos();
        Task<DadosPagamento> ObterDadosPagamentoPorId(Guid id);
        Task CriarDadosPagamento(DadosPagamento dadosPagamento);
        Task AtualizarDadosPagamento(DadosPagamento dadosPagamento);
        Task DeletarDadosPagamento(Guid id);
    }
}
