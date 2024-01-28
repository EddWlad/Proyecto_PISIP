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

        public IEnumerable<PagoDiarioRegistro> ListarPagosActivos()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    var pagosRegistros = context.Pago_diario
                     .Join(context.Registro_Asistencia,
                         p => p.id_registro,
                         r => r.id_registro,
                        (pago, registro) => new { pago, registro })
                     .Join(context.Cliente,
                        nc => nc.registro.id_cliente,
                        c => c.id_cliente,
                        (nombreCliente, clientes) => new PagoDiarioRegistro
                        {
                            id_pago_diario = nombreCliente.pago.id_pago_diario,
                            cedula = clientes.cedula,
                            nombre = clientes.nombre,
                            fecha = nombreCliente.pago.fecha,
                            costo = nombreCliente.pago.monto,
                            estado = nombreCliente.pago.estado
                        }).Where(p => p.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return pagosRegistros.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
