using Microsoft.Extensions.Configuration;
using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Nurses_Scale.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly string _connection;

        public PacienteRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Paciente>> ObterTodosAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.Query<Paciente>("SELECT * FROM pacientes");
            }
        }

        public async Task<Paciente> ObterPorIdAsync(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<Paciente>("SELECT * FROM pacientes WHERE PacienteId = @Id", new { Id = id });
            }
        }

        public async Task InserirAsync(Paciente paciente)
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var pacienteFormatado = new Paciente()
                {
                    Nome = paciente.Nome,
                    CPF = paciente.CPF.Replace(".", "").Replace("-", ""),
                    RG = paciente.RG.Replace(".", "").Replace("-", ""),
                    Email = paciente.Email,
                    Telefone = paciente.Telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""),
                    ClienteId = paciente.ClienteId,
                    DataNascimento = paciente.DataNascimento,
                    Cep = paciente.Cep.Replace(".", "").Replace("-",""),
                    Endereco = paciente.Endereco,
                    Numero = paciente.Numero,
                    Complemento = paciente.Complemento,
                    Bairro = paciente.Bairro,
                    Cidade = paciente.Cidade,
                    Estado = paciente.Estado
                };

                string query = "INSERT INTO pacientes (Nome, DataNascimento, ClienteID, CPF, RG, Email, Telefone, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Estado) " +
                               "VALUES (@Nome, @DataNascimento, @ClienteId, @CPF, @RG, @Email, @Telefone, @Cep, @Endereco, @Numero, @Complemento, @Bairro, @Cidade, @Estado)";
                connection.Execute(query, pacienteFormatado);
            }
        }

        public async Task AtualizarAsync(Paciente paciente)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_connection))
                {
                    var pacienteFormatado = new Paciente()
                    {
                        PacienteId = paciente.PacienteId,
                        Nome = paciente.Nome,
                        CPF = paciente.CPF.Replace(".", "").Replace("-", ""),
                        RG = paciente.RG.Replace(".", "").Replace("-", ""),
                        Email = paciente.Email,
                        Telefone = paciente.Telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""),
                        ClienteId = paciente.ClienteId,
                        DataNascimento = paciente.DataNascimento,
                        Cep = paciente.Cep.Replace(".", "").Replace("-", ""),
                        Endereco = paciente.Endereco,
                        Numero = paciente.Numero,
                        Complemento = paciente.Complemento,
                        Bairro = paciente.Bairro,
                        Cidade = paciente.Cidade,
                        Estado = paciente.Estado
                    };

                    string query = "UPDATE pacientes SET Nome = @Nome, " +
                                   "                    DataNascimento = @DataNascimento, " +
                                   "                    ClienteID = @ClienteID, " +
                                   "                    CPF = @CPF, " +
                                   "                    RG = @RG, " +
                                   "                    Email = @Email, " +
                                   "                    Telefone = @Telefone, " +
                                   "                    Cep = @Cep, " +
                                   "                    Endereco = @Endereco, " +
                                   "                    Numero = @Numero, " +
                                   "                    Complemento = @Complemento, " +
                                   "                    Bairro = @Bairro, " +
                                   "                    Cidade = @Cidade, " +
                                   "                    Estado = @Estado  " +
                                   "WHERE PacienteId = @PacienteId";
                    connection.Execute(query, pacienteFormatado); 
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        public async Task ExcluirAsync(Guid id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_connection))
                {
                    string query = "DELETE FROM pacientes WHERE PacienteId = @Id";
                    connection.Execute(query, new { Id = id });
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
