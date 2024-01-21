using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class PagoDiarioRepository : BaseRepository<Pago_diario>, IPagoDiarioRepository
    {
        public IEnumerable<Pago_diario> ListarPagosFecha(DateTime fecha)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var pagoDiarioFecha = from e in context.Pago_diario
                                          where e.fecha == fecha
                                          select e;
                    //3.- retorno resultado
                    return pagoDiarioFecha.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Pago_diario> ListarPagosActivos()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var pagosActivos = from e in context.Pago_diario
                                            where e.estado == true
                                            select e;
                    //3.- retorno resultado
                    return pagosActivos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
