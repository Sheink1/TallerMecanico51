using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Core.Models.Entidades;


namespace Taller.Core.Models.Entidades
{
    public class OrdenServicioDetalle
    {
        [Key]
        public int IdOrdenServicioDetalle { get; set; }
        
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public int IdOrdenServicio { get; set; }
        public int IdServicio { get; set; }
        public Double Cantidad { get; set; }

        public Double Costo { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraFinal { get; set; }

        [NotMapped]
        public double Importe {get{return Costo  * Cantidad;}}

        [NotMapped]
        public virtual OrdenServicio OrdenServicio  {get; set;}
        
        [NotMapped]
        public virtual Servicio Servicio {get; set;}




    }
}