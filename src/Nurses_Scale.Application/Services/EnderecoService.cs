using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Domain.Entities;
using Nurses_Scale.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            await _enderecoRepository.AtualizarAsync(endereco);
        }

        public async Task CriarEndereco(Endereco endereco)
        {
            await _enderecoRepository.InserirAsync(endereco);
        }

        public async Task DeletarEndereco(Guid id, Guid enderecoId)
        {
            await _enderecoRepository.ExcluirAsync(id, enderecoId);
        }

        public async Task<Endereco> ObterEnderecoPorId(Guid id, Guid enderecoId)
        {
            return await _enderecoRepository.ObterPorIdAsync(id, enderecoId);
        }

        public async Task<IEnumerable<Endereco>> ObterTodosEnderecos(Guid id)
        {
            return await _enderecoRepository.ObterTodosEnderecosAsync(id);
        }
    }
}
