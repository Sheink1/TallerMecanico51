using System;
using System.Collections.Generic;
using Taller.Core.Models.Entidades;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taller.API.Interfaces;

namespace Taller.Api.Data
{
    public class BaseDatos<T> : IBaseDatos<T> where T:class
    {
        TallerContext taller;
        DbSet <T> entidad;
        
        public BaseDatos(TallerContext context){
            taller = context;
            entidad = taller.Set<T>();
        }
        public bool Actualizar(T obj)
        {
            try{
                entidad.Update(obj);
                taller.SaveChanges();
                return true;
            }
            catch{
                return false;
            }
            
        }

        public bool Borrar(int id)
        {
            try{
                var borrar = entidad.Find(id);
                entidad.Remove(borrar);
                taller.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool Borrar(List<T> lista)
        {
            try{
                
                entidad.RemoveRange(lista);
                taller.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }


        public bool Borrar()
        {
            throw new NotImplementedException();
        }

        public (T objeto, bool valido) GuardarMD(T obj)
        {
           try
            {
                entidad.Add(obj);
                taller.SaveChanges();
                return (obj ,true);
            }
            catch 
            {
                return (null, false);
            }

        }

        public bool Guardar(T obj)
        {
            try{
               entidad.Add(obj);
            taller.SaveChanges();
            return true;  
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public List<T> Listar()
        {
           return(entidad.ToList());
        }
    }
}

    