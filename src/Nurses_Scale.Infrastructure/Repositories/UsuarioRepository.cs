using Microsoft.Extensions.Configuration;
using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Text;
using System.Security.Cryptography;

namespace Nurses_Scale.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connection;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<Usuario>("SELECT * FROM usuarios");
            }
        }

        public async Task<Usuario> ObterPorIdAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<Usuario>("SELECT * FROM usuarios WHERE UsuarioId = @Id", new { Id = id });
            }
        }

        public async Task<Usuario> ObterPorNomeUsuarioAsync(string nomeUsuario)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirst<Usuario>("SELECT * FROM usuarios WHERE Email = @Email", new { Email  = nomeUsuario});
            }
        }

        public async Task InserirAsync(Usuario usuario)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "INSERT INTO usuarios (Nome, Email, SenhaHash) VALUES (@Nome, @Email, @SenhaHash)";
                connection.Execute(query, usuario);
            }
        }

        public async Task AtualizarSenhaAsync(string novaSenha, Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "UPDATE usuarios SET SenhaHash = @SenhaHash WHERE UsuarioId = @UsuarioId";
                connection.Execute(query, novaSenha);
            }
        }

        public async Task ExcluirAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "DELETE FROM usuarios WHERE UsuarioId = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
