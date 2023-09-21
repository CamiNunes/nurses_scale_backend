using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<Usuario> ObterPorIdAsync(Guid id);
        Task<Usuario> ObterPorNomeUsuarioAsync(string nomeUsuario);
        Task InserirAsync(Usuario usuario);
        Task AtualizarSenhaAsync(string novaSenha, Guid id);
        Task ExcluirAsync(Guid id);
    }
}
