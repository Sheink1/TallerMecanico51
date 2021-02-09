using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Taller.Core.Models.Entidades;
using Taller.API.Interfaces;


namespace  Taller.API.Controllers{

    [ApiController]
    [Route("[Controller]")]
    public class ClienteController:ControllerBase{

        IBaseDatos<Cliente> BaseDatos;
       public ClienteController(IBaseDatos<Cliente> context)
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
            return Ok(BaseDatos.Listar().Where(x=> x.IdCliente==id).FirstOrDefault());
            
        }

         [HttpPost]
        public IActionResult PostModelo(Cliente modelo)
        {
            if(ModelState.IsValid)
            {
               if(BaseDatos.Guardar(modelo)){
                    return Ok(modelo);
               }
                
            }
            
            return BadRequest();
            
            
            
        }

        [HttpPut("{id}")]
        public IActionResult PutModelo(int id, Cliente modelo){
            if(ModelState.IsValid)
            {
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



