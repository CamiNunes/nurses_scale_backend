using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Interfaces.Repositories;
using Nurses_Scale.Domain.Repositories.Interfaces;
using Nurses_Scale.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        static string GerarHashSenha(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private static bool VerificarHashSenha(string password, string hash)
        {
            string hashOfInput = GerarHashSenha(password);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            return await _usuarioRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _usuarioRepository.ObterTodosAsync();
        }

        public async Task<Usuario> ObterUsuarioPorNome(string nomeUsuario)
        {
            return await _usuarioRepository.ObterPorNomeUsuarioAsync(nomeUsuario);
        }

        public async Task CriarUsuario(RegistrarUsuario registrarUsuario)
        {
            //var usuarioExistente = _usuarioRepository.ObterPorNomeUsuarioAsync(registrarUsuario.Email);
            //if (usuarioExistente.Count() != 0)
            //{
            //    throw new Exception("Usuário com o email " + registrarUsuario.Email + " já existe.");
            //}

            var usuarioFormatado = new Usuario()
            {
                Nome = registrarUsuario.Nome,
                Email = registrarUsuario.Email,
                SenhaHash = GerarHashSenha(registrarUsuario.Senha),
            };

            await _usuarioRepository.InserirAsync(usuarioFormatado);
        }

        public async Task<Usuario> LoginAsync(string nomeUsuario, string senha)
        {
            var usuario = new Usuario();
            usuario = _usuarioRepository.ObterPorNomeUsuarioAsync(nomeUsuario).Result;
            
            if (usuario == null || !VerificarHashSenha(senha, usuario.SenhaHash))
            {
                return null; // Autenticação falhou.
            }

            return usuario;
        }

        public async Task AtualizarSenhaUsuario(string novaSenha, Guid id)
        {
            await _usuarioRepository.AtualizarSenhaAsync(novaSenha, id);
        }

        public async Task DeletarUsuario(Guid id)
        {
            await _usuarioRepository.ExcluirAsync(id);
        }
    }
}
