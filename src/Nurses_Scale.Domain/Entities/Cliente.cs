using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Entities
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }

        [StringLength(120)]
        public string RazaoSocial { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required]
        public string CNPJ { get; set; } = string.Empty;
        public string InscricaoEstadual { get; set; } = string.Empty;

        [Required]
        public string EmailPrincipal { get; set; } = string.Empty;

        [Required]
        public string TelefonePrincipal { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;
    }
}
