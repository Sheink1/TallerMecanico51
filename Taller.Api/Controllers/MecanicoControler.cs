using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Taller.Core.Models.Entidades;
using Taller.API.Interfaces;



namespace Taller.API.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class Mecanicocontroller : ControllerBase
    {
        IBaseDatos<Mecanico> BaseDatos;
    
     public Mecanicocontroller(IBaseDatos<Mecanico> context)
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
        return Ok(BaseDatos.Listar().Where(x=> x.IdMecanico==id).FirstOrDefault());

     }


     [HttpPost]
     public IActionResult PostModelo(Mecanico modelo)
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
        public IActionResult putModelo(int id,Mecanico modelo)
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