using Microsoft.AspNetCore.Mvc;
using Taller.Web.Interface;
using Taller.Core.Models.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

    namespace Taller.Web.cotrollers
    {
        public class ServicioController:Controller
        {
            IBaseDatos<Servicio> BaseDatos;
            public ServicioController(IBaseDatos<Servicio> contexto)
            {
                BaseDatos=contexto;
                BaseDatos.nombre="servicio";
            }
    
            public  async Task <IActionResult> Index()
        {
            List<Servicio> servicios = await BaseDatos.Listar();
            return View(servicios);
        }
        public IActionResult Create()
        {
            
            Servicio obj=new Servicio();
            
            return View(obj);
        }

        [HttpPost]
        public  async Task <IActionResult> Create(Servicio obj)
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
            
            var obj=  await BaseDatos.Buscar(id);
            if(obj == null)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpPost]
        public async Task < IActionResult> Edit (Servicio obj)
        {
            
            if(ModelState.IsValid)
            {
                
                var resultado= await BaseDatos.Modificar(obj.IdServicio, obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task <IActionResult> Edit(int id)
        {
            
            var obj=  await BaseDatos.Buscar(id);
            
            if(obj == null)
            {
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