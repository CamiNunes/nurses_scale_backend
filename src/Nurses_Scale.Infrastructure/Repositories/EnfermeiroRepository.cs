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
    public class EnfermeiroRepository : IEnfermeiroRepository
    {
        private readonly string _connection;

        public EnfermeiroRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Enfermeiro>> ObterTodosAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<Enfermeiro>("SELECT * FROM enfermeiros");
            }
        }

        public async Task<Enfermeiro> ObterPorIdAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<Enfermeiro>("SELECT * FROM enfermeiros WHERE EnfermeiroId = @Id", new { Id = id });
            }
        }

        public async Task InserirAsync(Enfermeiro enfermeiro)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var enfermeiroFormatado = new Enfermeiro()
                {
                    Nome = enfermeiro.Nome,
                    COFEN = enfermeiro.COFEN,
                    CPF = enfermeiro.CPF.Replace(".", "").Replace("-", ""),
                    RG = enfermeiro.RG.Replace(".", "").Replace("-", ""),
                    Email = enfermeiro.Email,
                    Telefone = enfermeiro.Telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""),
                    Banco = enfermeiro.Banco,
                    Agencia = enfermeiro.Agencia.Replace("-", ""),
                    Conta = enfermeiro.Conta.Replace("-", ""),
                    Cidade = enfermeiro.Cidade,
                    Estado = enfermeiro.Estado,
                    TipoChavePix = enfermeiro.TipoChavePix,
                    ChavePix = enfermeiro.TipoChavePix == enfermeiro.CPF || enfermeiro.TipoChavePix == enfermeiro.Telefone ? enfermeiro.ChavePix.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "") : enfermeiro.ChavePix
                };

                string query = "    INSERT INTO enfermeiros (Nome, COFEN, CPF, RG, Email, Telefone, Banco, Agencia, Conta, Cidade, Estado, TipoChavePix, ChavePix) " +
                               "    VALUES (@Nome, @COFEN, @CPF, @RG, @Email, @Telefone, @Banco, @Agencia, @Conta, @Cidade, @Estado, @TipoChavePix, @ChavePix)";
                connection.Execute(query, enfermeiroFormatado);
            }
        }

        public async Task AtualizarAsync(Enfermeiro enfermeiro)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var enfermeiroFormatado = new Enfermeiro()
                {
                    EnfermeiroId = enfermeiro.EnfermeiroId,
                    Nome = enfermeiro.Nome,
                    COFEN = enfermeiro.COFEN,
                    CPF = enfermeiro.CPF.Replace(".", "").Replace("-", ""),
                    RG = enfermeiro.RG.Replace(".", "").Replace("-", ""),
                    Email = enfermeiro.Email,
                    Telefone = enfermeiro.Telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""),
                    Banco = enfermeiro.Banco,
                    Agencia = enfermeiro.Agencia.Replace("-", ""),
                    Conta = enfermeiro.Conta.Replace("-", ""),
                    Cidade = enfermeiro.Cidade,
                    Estado = enfermeiro.Estado,
                    TipoChavePix = enfermeiro.TipoChavePix,
                    ChavePix = enfermeiro.TipoChavePix == enfermeiro.CPF || enfermeiro.TipoChavePix == enfermeiro.Telefone ? enfermeiro.ChavePix.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "") : enfermeiro.ChavePix
                };

                string query = "    UPDATE enfermeiros " +
                    "               SET Nome = @Nome, " +
                    "                   COFEN = @COFEN, " +
                    "                   CPF = @CPF, " +
                    "                   RG = @RG, " +
                    "                   Email = @Email, " +
                    "                   Telefone = @Telefone, " +
                    "                   Banco = @Banco, " +
                    "                   Agencia = @Agencia, " +
                    "                   Conta = @Conta, " +
                    "                   Cidade = @Cidade, " +
                    "                   Estado = @Estado, " +
                    "                   TipoChavePix = @TipoChavePix, " +
                    "                   ChavePix = @ChavePix " +
                    "               WHERE EnfermeiroId = @EnfermeiroId";
                connection.Execute(query, enfermeiroFormatado);
            }
        }

        public async Task ExcluirAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string query = "DELETE FROM enfermeiros WHERE EnfermeiroId = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
