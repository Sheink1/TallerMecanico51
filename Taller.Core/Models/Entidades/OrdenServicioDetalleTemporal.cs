using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Core.Models.Entidades;


namespace Taller.Core.Models.Entidades
{
    public class OrdenServicioDetalleTemporal
    {
        [Key]
        public int IdOrdenServicioDetalle { get; set; }

        [Required]      
        [Display(Name="Servicio")]  
        public int IdServicio { get; set; }

        public Double Cantidad { get; set; }

        public Double Costo { get; set; }
        [NotMapped]
        public double Importe { get{return Cantidad * Costo;} }
        

    }
}