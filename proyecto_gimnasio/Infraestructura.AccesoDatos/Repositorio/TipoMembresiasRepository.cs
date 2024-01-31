using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class TipoMembresiasRepository : BaseRepository<Tipo_Membresia>, ITipoMembresiaRepository
    {
        public bool ElminarTipoMembresia(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var tipoMembresia = context.Tipo_Membresia.FirstOrDefault(c => c.id_tipo_membresia == id);
                    if (tipoMembresia != null)
                    {
                        // 2.- Actualizar los campos necesarios

                        tipoMembresia.estado = false;


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

        public IEnumerable<Tipo_Membresia> ListarTipoMembresias(string descripcion)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var tiposMembresia = from e in context.Tipo_Membresia
                                        where e.descripcion == descripcion && e.estado == true
                                         select e;
                    //3.- retorno resultado
                    return tiposMembresia.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Tipo_Membresia> ListarTipoMembresiasActivas()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var tiposActivos = from e in context.Tipo_Membresia
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
