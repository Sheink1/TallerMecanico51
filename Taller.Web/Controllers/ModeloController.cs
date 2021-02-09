using Microsoft.AspNetCore.Mvc;
using Taller.Core.Models.Entidades;
using Taller.Web.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Taller.Web.Interface;
using System.Threading.Tasks;

namespace Taller.Web.cotrollers
{
    public class ModeloController:Controller
    {
        IBaseDatos<Modelo> BaseDatos;
        IBaseDatos<Marca> BdMarca;

        public ModeloController(IBaseDatos<Modelo> context, IBaseDatos<Marca> ctMarca)
        {
            BaseDatos = context;
            BdMarca = ctMarca;

            BdMarca.nombre="marca";
        }

        public async Task<IActionResult> Index()
        {
           BaseDatos.nombre = "Modelo"; 
           List<Modelo> modelos = await BaseDatos.Listar();
           List<Marca> marcas = await BdMarca.Listar();
           
           List<Modelo> Listado = (from md in modelos join ma in marcas on md.IdMarca equals  ma.IdMarca
           select new Modelo {
               IdModelo = md.IdModelo,
               Descripcion=md.Descripcion,
               IdMarca=md.IdMarca,
               Activo = md.Activo,
               Marca=ma
           }).ToList();
        /*
            List<Modelo> listado = (from md in modelos
                                     select new Modelo
                                     {
                                             IdModelo = md.IdModelo,
                                             IdMarca = md.IdMarca,
                                             Descripcion = md.Descripcion,
                                             Activo = md.Activo,
                                             Marca = (from ma in marcas
                                                       where ma.IdMarca == md.IdMarca
                                                      select new Marca
                                                      {
                                                         IdMarca = ma.IdMarca,
                                                         Descripcion = ma.Descripcion,
                                                         Activo = ma.Activo
                                                       }).FirstOrDefault()
                                                }).ToList();
          
                
            */
          return View(modelos);             
        }

        
        [HttpGet]
      public async Task<IActionResult> Create()
      {
        Modelo modelo=new Modelo();
         
         ViewBag.ListaMarcas= new SelectList(await BaseDatos.Listar(),"IdMarca","Descripcion");
          return View(modelo);
       }

       [HttpPost]
       public IActionResult Create(Modelo modelo)
       {
           if(ModelState.IsValid)
           {
               BaseDatos.nombre="modelo";
               BaseDatos.Guardar(modelo);
               return RedirectToAction("Index");
           
           }
            return View(modelo);
       }
 
       public async  Task <IActionResult> Info(int id)
       {
           BaseDatos.nombre="modelo";
           Modelo modelo= await BaseDatos.Buscar(id);
           if(modelo == null)
           {
               return RedirectToAction("Index");
           }
           ViewBag.ListaMarcas= new SelectList(await BdMarca.Listar(),"IdMarca","Descripcion",modelo.IdMarca);
           return View(modelo);
       }

      [HttpPost]
       public async Task<IActionResult> Edit (Modelo modelo)
       {
           if(ModelState.IsValid)
           {
               BaseDatos.nombre = "modelo";
              await BaseDatos.Modificar(modelo.IdModelo, modelo);
               return RedirectToAction("Index");
           }
           return View(modelo);
       }
      public async Task<IActionResult> Edit(int id)
       {
           BaseDatos.nombre="modelo";
           var modelo= await BaseDatos.Buscar(id);
           
           if(modelo == null)
           {
              return RedirectToAction("Index");
           }

           ViewBag.ListaMarcas= new SelectList(await BdMarca.Listar(),"IdMarca","Descripcion",modelo.IdMarca);
           return View(modelo);
       }

       public async Task<IActionResult> Delete(int id)
       {
           BaseDatos.nombre="modelo";
           await BaseDatos.Borrar(id);
           return RedirectToAction("index");
       }



    }
}