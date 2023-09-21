using Nurses_Scale.Domain.Entities;

namespace Nurses_Scale.Domain.Interfaces.Repositories
{
    public interface IAtendimentoRepository
    {
        Task<IEnumerable<Atendimento>> ObterTodosAsync();
        Task<Atendimento> ObterPorIdAsync(Guid id);
        Task InserirAsync(Atendimento atendimento);
        Task AtualizarAsync(Atendimento atendimento);
        Task ExcluirAsync(Guid id);
    }
}
