using Microsoft.AspNetCore.Mvc;
using Taller.Core.Models.Entidades;
using Taller.Web.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Taller.Web.Interface;

namespace Taller.Web.cotrollers
{
    public class MarcaController:Controller
    {
        IBaseDatos<Marca> BaseDatos;

        public MarcaController(IBaseDatos<Marca> context){
            BaseDatos = context;
        }
        public  async Task <IActionResult> Index()
        {
             BaseDatos.nombre = "marca";
            var Marcas= await BaseDatos.Listar();
            return View(Marcas);
        }
        [HttpGet]
      public IActionResult Create()
      {
          
        Marca marca=new Marca();
         
          return View(marca);
       }

       [HttpPost]
       public  async Task <IActionResult> Create(Marca marca)
       {
           if(ModelState.IsValid)
           {
                BaseDatos.nombre = "marca";
             await BaseDatos.Guardar(marca);
             
               return RedirectToAction("Index");
           
           }
            return View(marca);
       }
 
       public async Task <IActionResult> Info(int id)
       {
            BaseDatos.nombre = "marca";
           var marca= await BaseDatos.Buscar(id);
           if(marca == null)
           {
               return RedirectToAction("Index");
           }
           return View(marca);
       }

     

       public async Task <IActionResult> Edit(int id)
       {

           BaseDatos.nombre = "marca";
           var marca= await BaseDatos.Buscar(id);
           
           if(marca == null)
           {
              return RedirectToAction("Index");
           }
           return View(marca);
       }

        [HttpPost]
       public async Task < IActionResult> Edit (Marca marca)
       {
           if(ModelState.IsValid)
           {
                BaseDatos.nombre = "marca";
               var resultado = await BaseDatos.Modificar(marca.IdMarca,marca);
               return RedirectToAction("Index");
           }
           return View(marca);
       }
     

       public  async Task< IActionResult> Delete(int id)
       {
           BaseDatos.nombre = "marca";
           await BaseDatos.Borrar(id);
           return RedirectToAction("index");
       }



    }
}