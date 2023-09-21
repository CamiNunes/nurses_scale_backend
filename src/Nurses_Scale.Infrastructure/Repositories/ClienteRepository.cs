using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Repositories.Interfaces;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Nurses_Scale.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connection;

        public ClienteRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<Cliente>("SELECT ClienteID, RazaoSocial, NomeFantasia, CNPJ, InscricaoEstadual, EmailPrincipal, TelefonePrincipal, Estado, Cidade FROM clientes");
            }
        }

        public async Task<Cliente> ObterPorIdAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<Cliente>("SELECT ClienteID, RazaoSocial, NomeFantasia, CNPJ, InscricaoEstadual, EmailPrincipal, TelefonePrincipal, Estado, Cidade FROM clientes WHERE ClienteId = @Id", new { Id = id });
            }
        }

        public async Task InserirAsync(Cliente cliente)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var clienteFormatado = new Cliente()
                {
                    RazaoSocial = cliente.RazaoSocial,
                    NomeFantasia = cliente.NomeFantasia,
                    CNPJ = cliente.CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""),
                    InscricaoEstadual = cliente.InscricaoEstadual.Replace(".", ""),
                    EmailPrincipal = cliente.EmailPrincipal,
                    TelefonePrincipal = cliente.TelefonePrincipal.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-",""),
                    Estado = cliente.Estado,
                    Cidade = cliente.Cidade,
                };

                string query = "    INSERT INTO clientes (RazaoSocial, NomeFantasia, CNPJ, InscricaoEstadual, EmailPrincipal, TelefonePrincipal, Estado, Cidade) " +
                               "    VALUES (@RazaoSocial, @NomeFantasia, @CNPJ, @InscricaoEstadual, @EmailPrincipal, @TelefonePrincipal, @Estado, @Cidade)";
                connection.Execute(query, clienteFormatado);
            }
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var clienteFormatado = new Cliente()
                {
                    ClienteId = cliente.ClienteId,
                    RazaoSocial = cliente.RazaoSocial,
                    NomeFantasia = cliente.NomeFantasia,
                    CNPJ = cliente.CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""),
                    InscricaoEstadual = cliente.InscricaoEstadual.Replace(".", ""),
                    EmailPrincipal = cliente.EmailPrincipal,
                    TelefonePrincipal = cliente.TelefonePrincipal.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""),
                };

                string query = "    UPDATE clientes " +
                    "               SET RazaoSocial = @RazaoSocial, " +
                    "                   NomeFantasia = @NomeFantasia, " +
                    "                   CNPJ = @CNPJ, " +
                    "                   InscricaoEstadual = @InscricaoEstadual, " +
                    "                   EmailPrincipal = @EmailPrincipal, " +
                    "                   TelefonePrincipal = @TelefonePrincipal," +
                    "                   Estado = @Estado, " +
                    "                   Cidade = @Cidade" +
                    "               WHERE ClienteId = @ClienteId";
                connection.Execute(query, clienteFormatado);
            }
        }

        public async Task ExcluirAsync(Guid id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_connection))
                {
                    /*Verificar se existe algum paciente vinculado a esse cliente*/
                    string query = "DELETE FROM clientes WHERE ClienteId = @Id";
                    connection.Execute(query, new { Id = id });
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
