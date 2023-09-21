using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObterTodosClientes();
        Task<Cliente> ObterClientePorId(Guid id);
        Task CriarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task DeletarCliente(Guid id);
    }
}
