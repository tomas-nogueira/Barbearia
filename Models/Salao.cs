using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbearia.Models
{
    [Table("Salao")]
    public class Salao
    {
        [Column("SalaoId")]
        [Display(Name = "Id do salão")]
        public int Id { get; set; }

        [Column("NameSalao")]
        [Display(Name = "Nome do salão")]
        public string NameSalao { get; set; } = string.Empty;

        [Column("CidadeSalao")]
        [Display(Name = "Cidade do salão")]
        public string CidadeSalao { get; set; } = string.Empty;

        [Column("RuaSalao")]
        [Display(Name = "Rua do salão")]
        public string RuaSalao { get; set; } = string.Empty;

        [Column("BairroSalao")]
        [Display(Name = "Bairro do salão")]
        public string BairroSalao { get; set; } = string.Empty;

        [Column("CepSalao")]
        [Display(Name = "CEP do salão")]
        public string CepSalao { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
