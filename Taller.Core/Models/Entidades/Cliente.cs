using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Core.Models.Entidades
{
    public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [StringLength(120,ErrorMessage="El campo Nombre no puede tener mas de 120 caractereses")]
    [Required(ErrorMessage="El campo {0} es obligatorio")]
    public string Nombre { get; set; }

   [StringLength(10,MinimumLength=10)]
   [DataType(DataType.PhoneNumber, ErrorMessage="EL {0} no es valido")]
    public string Telefono { get; set; }


    [StringLength(100)]
    [DataType(DataType.EmailAddress,ErrorMessage="EL {0} no es valido")]
    public string Correo { get; set; }

    [Required(ErrorMessage="El campo {0} es obligatorio")]
    [Range(0,10000,ErrorMessage="El {0} debe estar entre {1} y {2}")]
    public decimal LimiteCredito { get; set; }


    [Required(ErrorMessage="El campo {0} es obligatorio")]
    public bool Activo { get; set; }
    [NotMapped]
    public virtual List<OrdenServicio> OrdenServicios { get; set; }

       
    }
    

}