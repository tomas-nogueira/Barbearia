using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbearia.Models
{
    [Table("TipoDocumento")]
    public class TipoDocumento
    {
        [Column("TipoDocumentoId")]
        [Display(Name = "Código do tipo de documento")]

        public int Id { get; set; }

        [Column("TipodeDocumento")]
        [Display(Name = "Tipo de documento")]

        public string TipodeDocumento { get; set; } = string.Empty;
    }
}
