using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> ObterTodosEnderecosAsync(Guid id);
        Task<Endereco> ObterPorIdAsync(Guid id, Guid enderecoId);
        Task InserirAsync(Endereco endereco);
        Task AtualizarAsync(Endereco endereco);
        Task ExcluirAsync(Guid id, Guid enderecoId);
    }
}
