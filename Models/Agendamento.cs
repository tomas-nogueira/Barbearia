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

        [ForeignKey("ServiceSalaoId")]
        public int ServiceSalaoId { get; set; }

        public ServiceSalao? ServiceSalao { get; set; }
    }
}
