using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class PagoDiarioRepository : BaseRepository<Pago_diario>, IPagoDiarioRepository
    {
        

        public IEnumerable<PagoDiarioRegistro> ListarPagosActivosFrecuentes()
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
                            tipo_cliente = clientes.Tipo_Cliente.descripcion,
                            estado = nombreCliente.pago.estado
                        }).Where(p => p.estado.Equals(true) && p.tipo_cliente.Equals("Frecuente")).ToList();
                    //3.- retorno resultado
                    return pagosRegistros.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public bool ElminarPago(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var pago = context.Pago_diario.FirstOrDefault(c => c.id_pago_diario == id);
                    if (pago != null)
                    {
                        // 2.- Actualizar los campos necesarios

                        pago.estado = false;


                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                        throw new Exception("El valor de pago es nulo");

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("No se pudo eliminar el registro del cliente.", ex);

            }
        }

        public IEnumerable<PagoDiarioRegistro> ListarPagosCedula(string cedula)
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
                            tipo_cliente = clientes.Tipo_Cliente.descripcion,
                            estado = nombreCliente.pago.estado
                        }).Where(p => p.estado.Equals(true) && p.cedula.Equals(cedula) && p.tipo_cliente.Equals("Frecuente")).ToList();
                    //3.- retorno resultado
                    return pagosRegistros.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<PagoDiarioRegistro> ListarPagosTipoCliente(string tipo)
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
                            tipo_cliente = clientes.Tipo_Cliente.descripcion,
                            estado = nombreCliente.pago.estado
                        }).Where( p => p.tipo_cliente.Equals(tipo) && p.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return pagosRegistros.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<PagoDiarioRegistro> ListarPagosFecha(DateTime fecha)
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
                            tipo_cliente = clientes.Tipo_Cliente.descripcion,
                            estado = nombreCliente.pago.estado
                        }).Where(p => p.fecha.Equals(fecha) && p.estado.Equals(true) && p.tipo_cliente.Equals("Frecuente")).ToList();
                    //3.- retorno resultado
                    return pagosRegistros.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<PagoDiarioRegistro> ListarPagosActivosMiembros()
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
                            tipo_cliente = clientes.Tipo_Cliente.descripcion,
                            estado = nombreCliente.pago.estado
                        }).Where(p => p.estado.Equals(true) && p.tipo_cliente.Equals("Miembro")).ToList();
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
