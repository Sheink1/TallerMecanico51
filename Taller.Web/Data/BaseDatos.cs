using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Taller.Core.Models.Entidades;
using Taller.Web.Interface;

namespace Taller.Web.Data
{
    public class BaseDatos<T> : IBaseDatos<T>
    {
        private string ruta = "https://localhost:5001/api/";
        public string nombre {get; set;}

        public async Task<bool> Borrar(int id)
        {
            HttpClient cliente= new HttpClient();
            HttpResponseMessage respuesta= await cliente.DeleteAsync($"{ruta}{this.nombre}/{id}");
            return true;
        }

        public async Task <bool> BorrarALL()
        {
            HttpClient cliente= new HttpClient();
            HttpResponseMessage respuesta= await cliente.DeleteAsync($"{ruta}{this.nombre}");
            return true;
            
        }

        public async Task<T> Buscar(int id)
        {
            HttpClient cliente = new HttpClient();

            HttpResponseMessage respuesta = await cliente.GetAsync($"{ruta}{this.nombre}/{id}");

            string r = await respuesta.Content.ReadAsStringAsync();

            T obj = JsonConvert.DeserializeObject<T>(r);

            return obj;
           
        }

        public async Task<T> Guardar(T obj)
        {
            HttpClient cliente = new HttpClient();

            StringContent contenido = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8,"application/Json");

            HttpResponseMessage respuesta=await cliente.PostAsync($"{ruta}{this.nombre}",contenido);

            var r = await respuesta.Content.ReadAsStringAsync();

            T mensaje =JsonConvert.DeserializeObject<T>(r);

            return mensaje;
        }

        public async Task<List<T>> Listar()
        {
            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.GetAsync($"{ruta}");

            string r= await respuesta.Content.ReadAsStringAsync();
            
            List<T> obj = JsonConvert.DeserializeObject<List<T>>(r);

            return obj;
        }

        public async Task<bool> Modificar(int id, T obj)
        {
            HttpClient cliente = new HttpClient();
               StringContent contenido = new StringContent(
                   JsonConvert.SerializeObject(obj),Encoding.UTF8,"application/Json"
                   );

               HttpResponseMessage respuesta= await cliente.PutAsync($"{ruta}{this.nombre}/{id}",contenido);
               return true;
        }
    }
   

}