using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Taller.API.Interfaces;
using Taller.Core.Models.Entidades;
//using Taller.API.Data;

namespace Taller.API.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class ServicioController : ControllerBase
    {
        IBaseDatos<Servicio> BaseDatos;
    
     public ServicioController(IBaseDatos<Servicio> context)
     {
        BaseDatos=context;
     }

       [HttpGet]
     public IActionResult GetallModelos()
     {
         return Ok(BaseDatos.Listar());
     }

     [HttpGet("{id}")]
     public IActionResult GetitemModelo(int id)
     {
        return Ok(BaseDatos.Listar().Where(x=> x.IdServicio==id).FirstOrDefault());

     }


     [HttpPost]
     public IActionResult PostModelo(Servicio modelo)
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
        public IActionResult putModelo(int id,Servicio modelo)
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