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
        public IEnumerable<AsistenciaCliente> ListarAsistenciaCedula(string cedula)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var registroAsistencias = context.Registro_Asistencia
                    .Join(context.Cliente,
                        c => c.id_cliente,
                        t => t.id_cliente,
                       (asistencia, cliente) => new AsistenciaCliente
                       {
                           id_registro = asistencia.id_registro,
                           cedula = cliente.cedula,
                           nombre = cliente.nombre,
                           telefono = cliente.telefono,
                           fecha = (DateTime)asistencia.fecha,
                           estado = asistencia.estado,
                       }).Where(c => c.cedula.Equals(cedula) && c.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return registroAsistencias.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Registro_Asistencia> ListarAsistenciaFecha(string fecha)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var registrosFechas = from e in context.Registro_Asistencia
                                          where e.fecha.Value.Month.ToString() == fecha
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

        public bool EliminarRegistro(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var registro = context.Registro_Asistencia.FirstOrDefault(c => c.id_registro == id);
                    if (registro != null)
                    {
                        // 2.- Actualizar los campos necesarios

                        registro.estado = false;


                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                        throw new Exception("El valor de registro es nulo");

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("No se pudo eliminar el registro de asistencia.", ex);

            }
        }

        public IEnumerable<AsistenciaCliente> ListarAsistencias()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var registroAsistencias = context.Registro_Asistencia
                    .Join(context.Cliente,
                        c => c.id_cliente,
                        t => t.id_cliente,
                       (asistencia, cliente) => new AsistenciaCliente
                       {
                           id_registro = asistencia.id_registro,
                           cedula = cliente.cedula,
                           nombre = cliente.nombre,
                           telefono = cliente.telefono,
                           fecha = (DateTime)asistencia.fecha,
                           estado = asistencia.estado,
                       }).Where(c => c.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return registroAsistencias.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
