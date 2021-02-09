using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Core.Models.Entidades;

namespace Taller.Core.Models.Entidades
{
    public class Modelo
    {
        [Key]
        [Display(Name="Codigo")]
        public int IdModelo { get; set; }

        [StringLength(80, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display(Name="Marca")]
        public int IdMarca { get; set; }
        
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [UIHint("Activo")]
        [Display(Name="Estatus")]
         public bool Activo { get; set; }
        
        [NotMapped]
        public virtual Marca Marca { get; set; }
    }
}