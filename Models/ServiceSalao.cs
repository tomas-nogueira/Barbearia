﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbearia.Models
{
    [Table("ServiceSalao")]
    public class ServiceSalao
    {
        [Column("ServiceSalaoId")]
        [Display(Name = "Código do serviço")]
        public int Id { get; set; }

        [ForeignKey("SalaoId")]
        public int SalaoId { get; set; }
        public Salao? Salao { get; set;}

        [ForeignKey("ServiceId")]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
