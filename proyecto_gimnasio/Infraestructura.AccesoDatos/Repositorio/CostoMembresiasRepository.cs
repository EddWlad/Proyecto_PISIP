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
        public IEnumerable<Costo_Membresia> ListarCostoMembresia(string descripcion)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var costoDescripcion = from e in context.Costo_Membresia
                                            where e.descripcion == descripcion
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
