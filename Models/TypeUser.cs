using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbearia.Models
{
    [Table("TypeUser")]
    public class TypeUser
    {
        [Column("TypeUserId")]
        [Display(Name = "Código do tipo de usuário")]
        public int Id { get; set; }

        [Column("TypeNameUser")]
        [Display(Name = "Digite o tipo de usuário")]
        public string TypeNameUser { get; set; } = string.Empty;
    }
}
