using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Core.Models.Enumeradores;
using Taller.Core.Models.Entidades;
namespace Taller.Core.Models.Entidades
{
    public class OrdenServicio
    {
        public OrdenServicio()
        {
            this.DetalleServicio = new List<OrdenServicioDetalle>();
        }
        [Key]
        public int IdOrdenServicio { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display(Name="Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display(Name="Mecanico")]
        public int IdMecanico { get; set; }
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public bool Autorizada { get; set; }
        public DateTime? FechaAutorizada { get; set; }
        public DateTime? FechaTerminado { get; set; }
        
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public EstatusOrdenServicio Estatus { get; set; }
        
        [NotMapped]
        public virtual Cliente Cliente {get; set;}
        [NotMapped]
        public virtual Mecanico Mecanicos {get; set;}

        [NotMapped]
        public virtual List<OrdenServicioDetalle> DetalleServicio {get; set;}


    }
}