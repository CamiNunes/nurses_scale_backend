using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Entities
{
    public class DadosPagamento
    {
        public Guid DadosPagamentoId { get; set; }
        public Guid EnfermeiroId { get; set; }
        public string TipoChavePix { get; set; } = string.Empty;
        public string ChavePix { get; set; } = string.Empty;
        public string Banco { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
        public string Conta { get; set; } = string.Empty;
    }
}
