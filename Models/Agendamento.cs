using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbearia.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Column("AgendamentoId")]
        [Display(Name = "Código do agendamento")]
        public int AgendamentoId { get; set; }

        [Column("HorarioAgendamento")]
        [Display(Name = "Digite o horário do agendamento")]
        public DateTime HorarioAgendamento { get; set; }

        [ForeignKey("ServiceId")]
        public int ServiceId { get; set; }

        public Service? Service { get; set; }

        [ForeignKey("SalaoId")]
        public int SalaoId { get; set; }

        public Salao? Salao { get; set; }
    }
}
