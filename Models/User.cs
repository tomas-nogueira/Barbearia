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

        [Column("DocumentoUser")]
        [Display(Name = "Documento do usuário")]

        public string DocumentoUser { get; set; } = string.Empty;

        [ForeignKey("TipoDocumentoId")]

        public int TipoDocumentoId { get; set; }

        public TipoDocumento? TipoDocumento { get; set; }

        [ForeignKey("TypeUserId")] 
        public int TypeUserId { get; set; }

        public TypeUser? TypeUser { get; set; }

        [Column("SenhaUser")]
        [Display(Name = "Digite a senha do usuário")]
        public string SenhaUser { get; set; } = string.Empty;

    }
}
