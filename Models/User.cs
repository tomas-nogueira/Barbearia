using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbearia.Models
{
    [Table("User")]
    public class User
    {
        [Column("UserId")]
        [Display(Name = "Código do usuário")]
        public int Id { get; set; }

        [Column("NameUser")]
        [Display(Name = "Digite o nome do usuário")]
        public string NameUser { get; set; } = string.Empty;

        [Column("TelUser")]
        [Display(Name = "Digite o telefone do usuário")]
        public string TelUser { get; set; } = string.Empty;

        [Column("EmailUser")]
        [Display(Name = "Digite o email do usuário")]
        public string EmailUser { get; set; } = string.Empty;

        [Column("CpfUser")]
        [Display(Name = "Digite o CPF do usuário")]
        public string CpfUser { get; set; } = string.Empty;


        [Column("CnpjUser")]
        [Display(Name = "Digite o CNPJ do usuário")]
        public string CnpjUser { get; set; } = string.Empty;

        [ForeignKey("TypeUserId")] 
        public int TypeUserId { get; set; }

        public TypeUser? TypeUser { get; set; }

        [Column("SenhaUser")]
        [Display(Name = "Digite a senha do usuário")]
        public string SenhaUser { get; set; } = string.Empty;

    }
}
