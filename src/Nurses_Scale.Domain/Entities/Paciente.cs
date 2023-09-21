using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Domain.Entities
{
    public class Paciente
    {
        public Guid PacienteId { get; set; }
        public Guid ClienteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }

        public string CPF { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        [StringLength(250)]
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}
