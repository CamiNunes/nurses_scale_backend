using Microsoft.Extensions.Configuration;
using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Nurses_Scale.Infrastructure.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly string _connection;

        public AtendimentoRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Atendimento>> ObterTodosAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<Atendimento>("SELECT * FROM tb_atendimentos");
            }
        }

        public async Task<Atendimento> ObterPorIdAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<Atendimento>("SELECT * FROM tb_atendimentos WHERE AtendimentoId = @Id", new { Id = id });
            }
        }

        public async Task InserirAsync(Atendimento atendimento)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "INSERT INTO tb_atendimentos (PacienteID, ClienteID, EnfermeiroID, DataInicial, DataFinal, Assistencia, ValorEmpresa, ValorProfissional, Status, TaPago)  " +
                               "VALUES (@PacienteID, @ClienteID, @EnfermeiroID, @DataInicial, @DataFinal, @Assistencia, @ValorEmpresa, @ValorProfissional, @Status, @TaPago)";
                connection.Execute(query, atendimento);
            }
        }

        public async Task AtualizarAsync(Atendimento atendimento)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "UPDATE tb_atendimentos SET PacienteID = @PacienteID, " +
                    "                                      ClienteID = @ClienteID, " +
                    "                                      EnfermeiroID = @EnfermeiroID, " +
                    "                                      DataInicial = @DataInicial, " +
                    "                                      DataFinal = @DataFinal, " +
                    "                                      Assistencia = @Assistencia, " +
                    "                                      ValorEmpresa = @ValorEmpresa, " +
                    "                                      ValorProfissional = @ValorProfissional, " +
                    "                                      Status = @Status, " +
                    "                                      TaPago = @TaPago " +
                    "           WHERE AtendimentoId = @AtendimentoId";
                connection.Execute(query, atendimento);
            }
        }

        public async Task ExcluirAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "DELETE FROM tb_atendimentos WHERE AtendimentoId = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
