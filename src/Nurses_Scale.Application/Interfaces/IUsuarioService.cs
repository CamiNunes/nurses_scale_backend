using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();
        Task<Usuario> ObterUsuarioPorId(Guid id);
        Task<Usuario> ObterUsuarioPorNome(string nomeUsuario);
        Task CriarUsuario(RegistrarUsuario registrarUsuario);
        Task AtualizarSenhaUsuario(string novaSenha, Guid id);
        Task DeletarUsuario(Guid id);
        Task<Usuario> LoginAsync(string nomeUsuario, string senha);
    }
}
