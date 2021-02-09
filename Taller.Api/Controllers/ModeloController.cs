using Microsoft.AspNetCore.Mvc;
using Taller.Api.Data;
using Taller.Core.Models.Entidades;
using System.Linq;
using Taller.API.Interfaces;

namespace Taller.API.Controllers{

    [ApiController]
    [Route("api/[Controller]")]    
    public class ModeloController:ControllerBase
    {
       
       IBaseDatos<Modelo> BaseDatos;
       public ModeloController(IBaseDatos<Modelo> context)
       {
           BaseDatos = context;
       }
       
        [HttpGet]
        public IActionResult GetallModelos(){

            return Ok(BaseDatos.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetItemModelo(int id)
        {
            return Ok(BaseDatos.Listar().Where(x=> x.IdModelo==id).FirstOrDefault());
            
        }

         [HttpPost]
        public IActionResult PostModelo(Modelo modelo)
        {
            if(ModelState.IsValid)
            {
               if(BaseDatos.Guardar(modelo))
               {
                    return Ok(modelo);
               }
                
            }
            
                return BadRequest();
            
            
            
        }

        [HttpPut("{id}")]
        public IActionResult PutModelo(int id, Modelo modelo){
            if(ModelState.IsValid){
                BaseDatos.Actualizar(modelo);
                return Ok(modelo);
            }
            else{
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModelo(int id){
            BaseDatos.Borrar(id);
            return Ok("Se borro correctaente");
        }
    }
}