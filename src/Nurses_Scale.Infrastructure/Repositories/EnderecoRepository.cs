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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string _connection;

        public EnderecoRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AtualizarAsync(Endereco endereco)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    var enderecoFormatado = new Endereco()
                    {
                        EnderecoId = endereco.EnderecoId,
                        PacienteId = endereco.PacienteId,
                        Cep = endereco.Cep.Replace(".", "").Replace("-", ""),
                        Logradouro = endereco.Logradouro,
                        Numero = endereco.Numero,
                        Complemento = endereco.Complemento,
                        Bairro = endereco.Bairro,
                        Localidade = endereco.Localidade,
                        Uf = endereco.Uf,
                    };

                    await connection.ExecuteAsync("UpdateEndereco", new
                    {
                        EnderecoId = enderecoFormatado.EnderecoId,
                        PacienteId = enderecoFormatado.PacienteId,
                        Cep = enderecoFormatado.Cep,
                        Logradouro = enderecoFormatado.Logradouro,
                        Numero = enderecoFormatado.Numero,
                        Complemento = enderecoFormatado.Complemento,
                        Bairro = enderecoFormatado.Bairro,
                        Localidade = enderecoFormatado.Localidade,
                        Uf = enderecoFormatado.Uf,
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        public async Task ExcluirAsync(Guid id, Guid enderecoId)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    await connection.ExecuteAsync("DeleteEndereco", new { PacienteId = id, EnderecoId = enderecoId }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public async Task InserirAsync(Endereco endereco)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    var enderecoFormatado = new Endereco()
                    {
                        EnderecoId = endereco.EnderecoId,
                        PacienteId = endereco.PacienteId,
                        Cep = endereco.Cep.Replace(".", "").Replace("-", ""),
                        Logradouro = endereco.Logradouro,
                        Numero = endereco.Numero,
                        Complemento = endereco.Complemento,
                        Bairro = endereco.Bairro,
                        Localidade = endereco.Localidade,
                        Uf = endereco.Uf,
                    };

                    await connection.ExecuteAsync("InsertEndereco", enderecoFormatado, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public async Task<Endereco> ObterPorIdAsync(Guid id, Guid enderecoId)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<Endereco>("SELECT * FROM enderecos WHERE PacienteId = @Id AND EnderecoId = @EnderecoId", new { Id = id, EnderecoId = enderecoId });
            }
        }

        public async Task<IEnumerable<Endereco>> ObterTodosEnderecosAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<Endereco>("SELECT * FROM enderecos WHERE PacienteId = @Id", new { Id = id });
            }
        }
    }
}
