using Microsoft.AspNetCore.Mvc;
using Taller.Web.Interface;
using Taller.Core.Models.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taller.Web.Controllers
{
    public class MecanicoController:Controller
    {
        IBaseDatos<Mecanico> BaseDatos;

        public MecanicoController (IBaseDatos<Mecanico> contexto)
        {
            BaseDatos = contexto;
            BaseDatos.nombre="mecanido";

        }

        public async Task<IActionResult> Index()
        {
            List<Mecanico> mecanicos = await BaseDatos.Listar();
            return View(mecanicos);
        }

        
      public IActionResult Create()
      {
          
        Mecanico obj=new Mecanico();
         
          return View(obj);
       }

       [HttpPost]
       public  async Task <IActionResult> Create(Mecanico obj)
       {
           if(ModelState.IsValid)
           {
                
             await BaseDatos.Guardar(obj);
             
               return RedirectToAction("Index");
           
           }
            return View(obj);
       }

       public async Task <IActionResult> Info(int id)
       {
           
           var obj= await BaseDatos.Buscar(id);
           if(obj == null)
           {
               return RedirectToAction("Index");
           }
           return View(obj);
       }

       public async Task <IActionResult> Edit(int id)
       {

           var obj= await BaseDatos.Buscar(id);
           
           if(obj == null)
           {
              return RedirectToAction("Index");
           }
           return View(obj);
       }

        [HttpPost]
       public async Task < IActionResult> Edit (Mecanico obj)
       {
           if(ModelState.IsValid)
           {
               var resultado = await BaseDatos.Modificar(obj.IdMecanico,obj);
               return RedirectToAction("Index");
           }
           return View(obj);
       }

        public  async Task< IActionResult> Delete(int id)
        {
           await BaseDatos.Borrar(id);
           return RedirectToAction("index");
         }

    }
}