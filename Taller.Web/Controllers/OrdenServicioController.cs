using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taller.Core.Models.Entidades;
using Taller.Core.Models.Enumeradores;
using Taller.web.Interface;

namespace Taller.Web.cotrollers
{
    public class OrdenServicioController : Controller
    {
        IBaseDatos<OrdenServicio> BaseDatos;
        IBaseDatos<Mecanico> BDMecanico;
        IBaseDatos<Cliente> BDCliente;
        IBaseDatos<Servicio> BDServicio;
        IBaseDatos<OrdenServicioDetalleTemporal> BDTemporal;
        public OrdenServicioController(IBaseDatos<OrdenServicio> contexto,
        IBaseDatos<Mecanico> contextoMecanico,
        IBaseDatos<Cliente> contextoCliente,
        IBaseDatos<Servicio> contextoServicio,
        IBaseDatos<OrdenServicioDetalleTemporal> contextoTemporal)

        {
            BaseDatos = contexto;
            BDCliente = contextoCliente;
            BDMecanico = contextoMecanico;
            BDServicio = contextoServicio;
            BDTemporal = contextoTemporal;

            BaseDatos.nombre = "ordenservicio";
            BDCliente.nombre = "cliente";
            BDMecanico.nombre = "mecanico";
            BDServicio.nombre = "servicio";
            BDTemporal.nombre = "DetalleTemporal";
        }
        public async Task<IActionResult> Index()
        {
            var OrdenServicio = await BaseDatos.Listar();
            var cliente = await BDCliente.Listar();
            var mecanico = await BDMecanico.Listar();

            List<OrdenServicio> objs = (from os in OrdenServicio
                                        join cli in cliente on os.IdCliente equals cli.IdCliente
                                        join mec in mecanico on os.IdMecanico equals mec.IdMecanico
                                        select new OrdenServicio
                                        {
                                            IdOrdenServicio = os.IdOrdenServicio,
                                            Fecha = os.Fecha,
                                            IdCliente = os.IdCliente,
                                            IdMecanico = os.IdMecanico,
                                            Autorizada = os.Autorizada,
                                            FechaAutorizada = os.FechaAutorizada,
                                            FechaTerminado = os.FechaTerminado,
                                            Estatus = os.Estatus,
                                            Mecanico = mec,
                                            Cliente = cli

                                        }).ToList();
            return View(objs);
        }
        public async Task<IActionResult> Create( int id=0)
        {

            OrdenServicio obj = await BaseDatos.Buscar(id);
            if (obj == null)
            {
                obj = new OrdenServicio();
            }



            var temporal = await BDTemporal.Listar();
            var listaservicio = await BDServicio.Listar();

            ViewBag.ListaClientes = new SelectList(await BDCliente.Listar(), "IdCliente", "Nombre");
            ViewBag.ListaMecanico = new SelectList(await BDMecanico.Listar(), "IdMecanico", "Nombre");

            obj.Fecha = DateTime.Now;
            obj.Estatus = EstatusOrdenServicio.Activo;
            obj.Autorizada = false;

            List<OrdenServicioDetalle> detalle = (from t in temporal
                                                  join s in listaservicio on t.IdServicio equals s.IdServicio
                                                  select new OrdenServicioDetalle
                                                  {
                                                      IdOrdenServicio = 0,
                                                      IdOrdenServicioDetalle = t.IdOrdenServicioDetalle,
                                                      IdServicio = t.IdServicio,
                                                      Cantidad = t.Cantidad,
                                                      Costo = (decimal)t.Costo,
                                                      Servicio = s

                                                  }).ToList();
  
            obj.DetalleServicio = detalle;
            ViewBag.detalle = detalle;
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdenServicio obj)
        {

            if (ModelState.IsValid)
            {
                obj.DetalleServicio = ViewBag.detalle;
                await BaseDatos.Guardar(obj);
                await BDTemporal.BorrarAll();
                return RedirectToAction("Index");
                //return Json(obj);

            }

                 ViewBag.ListaClientes = new SelectList(await BDCliente.Listar(), "IdCliente", "Nombre", obj.IdCliente);
                 ViewBag.ListaMecanico = new SelectList(await BDMecanico.Listar(), "IdMecanico", "Nombre", obj.IdMecanico);
            return View(obj);
        }


        public async Task<IActionResult> Info(int id)
        {

            var obj = await BaseDatos.Buscar(id);
            if (obj == null)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrdenServicio obj)
        {

            if (ModelState.IsValid)
            {

                var resultado = await BaseDatos.Modificar(obj.IdOrdenServicio, obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int id)
        {

            var obj = await BaseDatos.Buscar(id);

            if (obj == null)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Delete(int id)
        {

            await BaseDatos.Borrar(id);
            return RedirectToAction("index");
        }
        public async Task<IActionResult> AddServicio( int id =0)
        {
            
            OrdenServicioDetalleTemporal detalle = await BDTemporal.Buscar(id);
            if(detalle== null)
            {
                detalle=new OrdenServicioDetalleTemporal();
            }
            ViewBag.IdMecanico=  TempData["Mecanico"];
             ViewBag.IdCliente =  TempData["Cliente"];
            //new OrdenServicioDetalleTemporal();
            ViewBag.ListaServicio = new SelectList(await BDServicio.Listar(), "IdServicio", "Descripcion");

            return View(detalle);
        }

        [HttpPost]
        public async Task<IActionResult> AddServicio(OrdenServicioDetalleTemporal detalle)
        {
            if (ModelState.IsValid)
            {
                if (detalle.IdOrdenServicioDetalle==0)
                {
                    await BDTemporal.Guardar(detalle);  
                }
                {
                    await BDTemporal.Modificar(detalle.IdOrdenServicioDetalle,detalle);
                }
                
                return RedirectToAction("Create");
            }
            ViewBag.ListaServicio = new SelectList(await BDServicio.Listar(), "IdServicio", "Descripcion");
            return View(detalle);
        }

        [HttpGet]
      public async Task<IActionResult> GetCostoServicio(int id)
      {
          Servicio obj = await BDServicio.Buscar(id);
          return new JsonResult(obj.Costo);
      }

      public async Task<IActionResult> DeleteItemTemporal(int id)
      {
          var temp = await BDTemporal.Listar();
          var obj = temp.Where(t => t.IdServicio== id).FirstOrDefault();
          await BDTemporal.Borrar(obj.IdOrdenServicioDetalle);
          return RedirectToAction("Create");
      }
}


}