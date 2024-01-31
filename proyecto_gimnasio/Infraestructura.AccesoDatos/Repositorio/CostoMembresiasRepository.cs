using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class CostoMembresiasRepository : BaseRepository<Costo_Membresia>, ICostoMembresiaRepository
    {
        public bool EliminarCostoMembresia(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var costoMembresia = context.Costo_Membresia.FirstOrDefault(c => c.id_costo_membresia == id);
                    if (costoMembresia != null)
                    {
                        // 2.- Actualizar los campos necesarios

                        costoMembresia.estado = false;

                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                        throw new Exception("El valor de tipo es nulo");

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("No se pudo borrar el registro del tipo.", ex);

            }
        }

        public IEnumerable<Costo_Membresia> ListarCosto(decimal costo)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var costos = from e in context.Costo_Membresia
                                        where e.valor == costo && e.estado == true
                                        select e;
                    //3.- retorno resultado
                    return costos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Costo_Membresia> ListarCostoMembresia(string descripcion)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var costoDescripcion = from e in context.Costo_Membresia
                                            where e.descripcion == descripcion && e.estado == true
                                           select e;
                    //3.- retorno resultado
                    return costoDescripcion.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Costo_Membresia> ListarCostosMembresiasActivas()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var tiposActivos = from e in context.Costo_Membresia
                                       where e.estado == true
                                       select e;
                    //3.- retorno resultado
                    return tiposActivos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
