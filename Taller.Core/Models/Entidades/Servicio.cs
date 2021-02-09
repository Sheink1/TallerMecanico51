using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Core.Models.Entidades
{
    public class Servicio
    {
        [Key]
        [Display(Name="Codigo")]
        public int IdServicio { get; set; }

        [StringLength(60, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public string Descripcion { get; set; }

        [StringLength(20, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public string Grupo { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public int Costo { get; set; }
        
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [UIHint("Activo")]
        [Display(Name="Estatus")]
        public bool Activo { get; set; }

        [NotMapped]
        public virtual List<Modelo> Modelos {get;set;}
        [NotMapped]
        public virtual List<OrdenServicioDetalle> DetalleServicio {get; set;}

    }
}