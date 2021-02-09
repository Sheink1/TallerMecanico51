using Microsoft.AspNetCore.Mvc;
using Taller.Api.Data;
using Taller.Core.Models.Entidades;
using System.Linq;
using Taller.API.Interfaces;

namespace Taller.API.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class OrdenServicioController : ControllerBase
    {
        IBaseDatos<OrdenServicio> BaseDatos;
    
     public OrdenServicioController(IBaseDatos<OrdenServicio> context)
     {
        BaseDatos=context;
     }

       [HttpGet]
     public IActionResult GetAllModelos()
     {
         return Ok(BaseDatos.Listar());
     }

     [HttpGet("{id}")]
     public IActionResult GetItemModelo(int id)
     {
        return Ok(BaseDatos.Listar().Where(x=> x.IdOrdenServicio==id).FirstOrDefault());

     }


     [HttpPost]
     public IActionResult PostModelo(OrdenServicio modelo)
    {
        if (ModelState.IsValid)
        {
          if ( BaseDatos.Guardar(modelo))
          {
            return Ok(modelo);
          }
           return Ok(modelo);
        }
        else{
            return BadRequest();
        }
    }
         [HttpPut("{id}")]
        public IActionResult putModelo(int id,OrdenServicio modelo)
        {

          if (ModelState.IsValid)
          {
              BaseDatos.Actualizar(modelo);
              return Ok(modelo);
          }
          return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModelo(int id)
        {
            BaseDatos.Borrar(id);
            return Ok("se borro el correctamente el registro");
        }

        

     } 

    }