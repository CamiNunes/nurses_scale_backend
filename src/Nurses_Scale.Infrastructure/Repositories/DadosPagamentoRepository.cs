using Microsoft.Extensions.Configuration;
using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Nurses_Scale.Infrastructure.Repositories
{
    public class DadosPagamentoRepository : IDadosPagamentoRepository
    {
        private readonly string _connection;

        public DadosPagamentoRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<DadosPagamento>> ObterTodosAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<DadosPagamento>("SELECT * FROM tb_dadosPagamentos");
            }
        }

        public async Task<DadosPagamento> ObterPorIdAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<DadosPagamento>("SELECT * FROM tb_dadosPagamentos WHERE DadosPagamentoId = @Id", new { Id = id });
            }
        }

        public async Task InserirAsync(DadosPagamento dadosPagamento)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "INSERT INTO tb_dadosPagamentos (EnfermeiroID, TipoChavePix, ChavePix, Banco, Agencia, Conta) VALUES (@EnfermeiroID, @TipoChavePix, @ChavePix, @Banco, @Agencia, @Conta)";
                connection.Execute(query, dadosPagamento);
            }
        }

        public async Task AtualizarAsync(DadosPagamento dadosPagamento)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "UPDATE tb_dadosPagamentos SET EnfermeiroID = @EnfermeiroID, TipoChavePix = @TipoChavePix, ChavePix = @ChavePix, Banco = @Banco, Agencia = @Agencia, Conta = @Conta WHERE DadosPagamentoId = @DadosPagamentoId";
                connection.Execute(query, dadosPagamento);
            }
        }

        public async Task ExcluirAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "DELETE FROM tb_dadosPagamentos WHERE DadosPagamentoId = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
