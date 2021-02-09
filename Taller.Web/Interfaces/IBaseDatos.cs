using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taller.Web.Interface
{
    public interface IBaseDatos<T>
    {
        string nombre {get; set;}

        Task<List<T>> Listar();
        Task<T> Buscar(int id);
        Task<T> Guardar(T obj);
        Task<bool> Modificar(int id,T obj);
        Task<bool> Borrar(int id);
        Task <bool> BorrarALL();
    }
}