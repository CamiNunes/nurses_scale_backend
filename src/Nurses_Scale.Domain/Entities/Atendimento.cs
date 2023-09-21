using Nurses_Scale.Domain.Enums;

namespace Nurses_Scale.Domain.Entities
{
    public class Atendimento
    {
        public Atendimento() 
        {
            Status = EnumStatus.Iniciado;
        }

        public Guid AtendimentoId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid EnfermeiroId { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public EnumStatus Status { get; set; }
        //public string? Status { get; set; }
        public string Assistencia { get; set; } = string.Empty;
        public decimal? ValorEmpresa { get; set; }
        public decimal? ValorProfissional { get; set; }
        public bool TaPago { get; set; }
    }
}
