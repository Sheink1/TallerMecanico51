using System.Collections.Generic;

namespace Taller.API.Interfaces
{
    public interface IBaseDatos<T>
    {
        List<T> Listar();
        bool Guardar(T obj);
        bool Actualizar(T obj);
        bool Borrar(int id);

        bool Borrar(List<T> lista);
        (T objeto, bool valido) GuardarMD(T obj); 

        //object listar();
    }
}