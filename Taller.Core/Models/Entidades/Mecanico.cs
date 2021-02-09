using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Core.Models.Entidades;
namespace Taller.Core.Models.Entidades
{
    public class Mecanico
    {
        [Key]
        public int IdMecanico { get; set; }

        [StringLength(120,ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [StringLength(10,MinimumLength=10)]
         [DataType(DataType.PhoneNumber, ErrorMessage="EL {0} no es valido")]
        public string Telefono { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress,ErrorMessage="EL {0} no es valido")] 
        public string Correo { get; set; }

        [Required]
        [UIHint("Activo")]
        public bool Activo { get; set; }
        
         [NotMapped]
        public virtual List<OrdenServicio> OrdenServicios { get; set; }
        
    }

}