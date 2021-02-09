using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Core.Models.Entidades
{
    public class Marca

    {
        [Key]
        [Display(Name="Codigo")]
        public int IdMarca { get; set; }

        [StringLength(80, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        //[Index(IsUnique=true)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display(Name="Estatus")]
        [UIHint("Activo")]
        public bool Activo { get; set; }

       [NotMapped]
        public virtual List<Modelo> Modelos { get; set; }

    }
}