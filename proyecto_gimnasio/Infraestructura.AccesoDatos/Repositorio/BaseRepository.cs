using Dominio.Modelo.Abstracciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("No se pudo guardar el registro");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    var entity = context.Set<TEntity>().Find(id);
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar registro");
            }
        }

        public void Modify(TEntity entity)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar registro");
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {

                   return context.Set<TEntity>().ToList();  
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros");
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {

                    return context.Set<TEntity>().Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registro");
            }
        }

        

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
