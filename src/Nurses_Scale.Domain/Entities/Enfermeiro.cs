using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Entities
{
    public class Enfermeiro
    {
        public Guid EnfermeiroId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;


        public string COFEN { get; set; } = string.Empty;

        [Required]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public string RG { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string TipoChavePix { get; set; } = string.Empty;
        public string ChavePix { get; set; } = string.Empty;
        public string Banco { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
        public string Conta { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
