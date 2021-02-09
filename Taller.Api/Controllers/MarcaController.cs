using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Taller.Api.Data;
using Taller.Core.Models.Entidades;
using Taller.API.Interfaces;

namespace Taller.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcaController: ControllerBase
    {
        IBaseDatos<Marca> Taller;
        public MarcaController(IBaseDatos<Marca> context){
            Taller=context;
        }

        [HttpGet]
        public IActionResult Getall(){

            return Ok(Taller.Listar());
        }

        [HttpGet ("{id}")]
        public IActionResult GetById(int id){
            return Ok (Taller.Listar().Where(x=> x.IdMarca==id).FirstOrDefault());
        }

        [HttpGet("descripcion/{name}")]
        public IActionResult GetByDescripcion(string name){
            return Ok(Taller.Listar().Where(x=>x.Descripcion.ToLower()==name.ToLower()).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Post(Marca marca)
        {
            if(ModelState.IsValid)
            {
                Taller.Guardar(marca);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok(marca);
                
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Marca marca){
            if(ModelState.IsValid){
                var modificar= Taller.Listar().Where(x=> x.IdMarca==id).FirstOrDefault();
                modificar.Descripcion=marca.Descripcion;
                modificar.Activo=marca.Activo;

               Taller.Actualizar(modificar);
                return Ok(modificar);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            
            Taller.Borrar(id);
            return Ok("Se borro");
        /*
        [HttpGet] //Consultar info
        [HttpPost] //Guardar informacion
        [HttpDelete] //Borrar info
        [HttpPut] //Actualizar info
        */
    }
}
}