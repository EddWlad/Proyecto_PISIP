using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class RegistroAsistenciaRepository : BaseRepository<Registro_Asistencia>, IRegistroAsistenciaRepository
    {
        public IEnumerable<Registro_Asistencia> ListarAsistenciaFecha(DateTime fecha)
        {
            try
            {
                using(var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var registrosFechas = from e in context.Registro_Asistencia
                                          where e.fecha == fecha
                                          select e;
                    //3.- retorno resultado
                    return registrosFechas.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
