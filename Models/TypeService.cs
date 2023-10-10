using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbearia.Models
{
    [Table("TypeService")]
    public class TypeService
    {
        [Column("ServiceId")]
        [Display(Name = "Número do serviço")]
        public int Id { get; set; }

        [Column("NameService")]
        [Display(Name = "Digite o tipo do serviço")]
        public string NameService { get; set; } = string.Empty;

        [Column("TimeService")]
        [Display(Name = "Digite a duração desse serviço")]
        public double TimeService { get; set; }


    }
}
