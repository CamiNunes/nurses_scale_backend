using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<Endereco>> ObterTodosEnderecos(Guid id);
        Task<Endereco> ObterEnderecoPorId(Guid id, Guid enderecoId);
        Task CriarEndereco(Endereco endereco);
        Task AtualizarEndereco(Endereco endereco);
        Task DeletarEndereco(Guid id, Guid enderecoId);
    }
}
