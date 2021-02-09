using Microsoft.AspNetCore.Mvc;
using Taller.Web.Interface;
using Taller.Core.Models.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taller.Web.cotrollers
{
    public class ClienteController:Controller
{
    IBaseDatos<Cliente> BaseDatos;
    public ClienteController(IBaseDatos<Cliente> contexto)
    {
        BaseDatos=contexto;
       BaseDatos.nombre="cliente";
    }
    public  async Task <IActionResult> Index()
    {
        List<Cliente> clientes = await BaseDatos.Listar();
        return View(clientes);
    }
public IActionResult Create()
      {
          
        Cliente obj=new Cliente();
         
          return View(obj);
       }

       [HttpPost]
       public  async Task <IActionResult> Create(Cliente obj)
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
       public async Task < IActionResult> Edit (Cliente obj)
       {
           
           if(ModelState.IsValid)
           {
              
              var resultado= await BaseDatos.Modificar(obj.IdCliente, obj);
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