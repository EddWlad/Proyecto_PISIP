using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public IEnumerable<ClienteTipoCliente> ListarClienteNombre(string nombre)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesActivos = context.Cliente
                    .Join(context.Tipo_Cliente,
                        c => c.id_tipo_cliente,
                        t => t.id_tipo_cliente,
                       (cliente, tipoCLiente) => new { cliente, tipoCLiente })
                    .Join(context.Membresias,
                        detalleMembresia => detalleMembresia.cliente.id_membresia,
                        membresia => membresia.id_membresia,
                        (detalleMembresia, membresia) => new ClienteTipoCliente
                        {
                            id_cliente = detalleMembresia.cliente.id_cliente,
                            tipoCliente = detalleMembresia.tipoCLiente.descripcion,
                            cedula = detalleMembresia.cliente.cedula,
                            nombre = detalleMembresia.cliente.nombre,
                            apellido = detalleMembresia.cliente.apellido,
                            direccion = detalleMembresia.cliente.direccion,
                            telefono = detalleMembresia.cliente.telefono,
                            email = detalleMembresia.cliente.email,
                            fecha_nacimiento = (DateTime)detalleMembresia.cliente.fecha_nacimiento,
                            peso = (decimal)detalleMembresia.cliente.peso,
                            altura = (decimal)detalleMembresia.cliente.altura,
                            estado = detalleMembresia.cliente.estado,
                            membresia = membresia.descripcion,
                            foto = (byte[])detalleMembresia.cliente.foto

                        }).Where(c => c.nombre.Equals(nombre) && c.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return clientesActivos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<ClienteTipoCliente> ListarClientesActivos()
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesActivos = context.Cliente
                    .Join(context.Tipo_Cliente,
                        c => c.id_tipo_cliente,
                        t => t.id_tipo_cliente,
                       (cliente,tipoCLiente) => new { cliente, tipoCLiente })
                    .Join(context.Membresias,
                        detalleMembresia => detalleMembresia.cliente.id_membresia,
                        membresia => membresia.id_membresia,
                        (detalleMembresia, membresia) => new ClienteTipoCliente
                        {
                           id_cliente = detalleMembresia.cliente.id_cliente,
                           tipoCliente = detalleMembresia.tipoCLiente.descripcion, 
                           cedula = detalleMembresia.cliente.cedula,
                           nombre = detalleMembresia.cliente.nombre,
                           apellido = detalleMembresia.cliente.apellido,
                           direccion = detalleMembresia.cliente.direccion,
                           telefono = detalleMembresia.cliente.telefono,
                           email = detalleMembresia.cliente.email,
                           fecha_nacimiento = (DateTime)detalleMembresia.cliente.fecha_nacimiento,
                           peso = (decimal)detalleMembresia.cliente.peso,
                           altura = (decimal)detalleMembresia.cliente.altura,
                           estado = detalleMembresia.cliente.estado,
                           membresia = membresia.descripcion,
                           foto = (byte[])detalleMembresia.cliente.foto

                        }).Where(c => c.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return clientesActivos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

       

        public void ModificarClientes(Cliente clienteActualizado)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var cliente = context.Cliente.FirstOrDefault(c => c.id_cliente == clienteActualizado.id_cliente);
                    if (cliente != null)
                    {
                        // 2.- Actualizar los campos necesarios
                        cliente.apellido = clienteActualizado.apellido;
                        cliente.nombre = clienteActualizado.nombre;
                        cliente.telefono = clienteActualizado.telefono;
                        cliente.direccion = clienteActualizado.direccion;
                        cliente.email = clienteActualizado.email;
                        cliente.estado = clienteActualizado.estado;
                        cliente.altura = clienteActualizado.altura;
                        cliente.peso = clienteActualizado.peso;

                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();
                       
                    }
                    else
                    {
                        throw new Exception("El valor de cliente es nulo");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el registro del cliente.", ex);
            }
        }

        public bool ElminarCliente(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var cliente = context.Cliente.FirstOrDefault(c => c.id_cliente == id);
                    if (cliente != null)
                    {
                        // 2.- Actualizar los campos necesarios

                        cliente.estado = false;


                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                        throw new Exception("El valor de cliente es nulo");
                        
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("No se pudo actualizar el registro del cliente.", ex);
                
            }
        }

        public IEnumerable<ClienteTipoCliente> ListarClientesTipo(string tipo)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesTipos = context.Cliente
                    .Join(context.Tipo_Cliente,
                        c => c.id_tipo_cliente,
                        t => t.id_tipo_cliente,
                       (cliente, tipoCLiente) => new { cliente, tipoCLiente })
                    .Join(context.Membresias,
                        detalleMembresia => detalleMembresia.cliente.id_membresia,
                        membresia => membresia.id_membresia,
                        (detalleMembresia, membresia) => new ClienteTipoCliente
                        {
                            id_cliente = detalleMembresia.cliente.id_cliente,
                            tipoCliente = detalleMembresia.tipoCLiente.descripcion,
                            cedula = detalleMembresia.cliente.cedula,
                            nombre = detalleMembresia.cliente.nombre,
                            apellido = detalleMembresia.cliente.apellido,
                            direccion = detalleMembresia.cliente.direccion,
                            telefono = detalleMembresia.cliente.telefono,
                            email = detalleMembresia.cliente.email,
                            fecha_nacimiento = (DateTime)detalleMembresia.cliente.fecha_nacimiento,
                            peso = (decimal)detalleMembresia.cliente.peso,
                            altura = (decimal)detalleMembresia.cliente.altura,
                            estado = detalleMembresia.cliente.estado,
                            membresia = membresia.descripcion,
                            foto = (byte[])detalleMembresia.cliente.foto

                        }).Where(ct => ct.tipoCliente.Equals(tipo) && ct.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return clientesTipos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<ClienteTipoCliente> ListarClientesCedula(string cedula)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesCedula = context.Cliente
                    .Join(context.Tipo_Cliente,
                        c => c.id_tipo_cliente,
                        t => t.id_tipo_cliente,
                       (cliente, tipoCLiente) => new { cliente, tipoCLiente })
                    .Join(context.Membresias,
                        detalleMembresia => detalleMembresia.cliente.id_membresia,
                        membresia => membresia.id_membresia,
                        (detalleMembresia, membresia) => new ClienteTipoCliente
                        {
                            id_cliente = detalleMembresia.cliente.id_cliente,
                            tipoCliente = detalleMembresia.tipoCLiente.descripcion,
                            cedula = detalleMembresia.cliente.cedula,
                            nombre = detalleMembresia.cliente.nombre,
                            apellido = detalleMembresia.cliente.apellido,
                            direccion = detalleMembresia.cliente.direccion,
                            telefono = detalleMembresia.cliente.telefono,
                            email = detalleMembresia.cliente.email,
                            fecha_nacimiento = (DateTime)detalleMembresia.cliente.fecha_nacimiento,
                            peso = (decimal)detalleMembresia.cliente.peso,
                            altura = (decimal)detalleMembresia.cliente.altura,
                            estado = detalleMembresia.cliente.estado,
                            membresia = membresia.descripcion,
                            foto = (byte[])detalleMembresia.cliente.foto

                        }).Where(ct => ct.cedula.Equals(cedula) && ct.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return clientesCedula.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<ClienteTipoCliente> ListarClienteMembresia(string membresias)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesMembresia = context.Cliente
                    .Join(context.Tipo_Cliente,
                        c => c.id_tipo_cliente,
                        t => t.id_tipo_cliente,
                       (cliente, tipoCLiente) => new { cliente, tipoCLiente })
                    .Join(context.Membresias,
                        detalleMembresia => detalleMembresia.cliente.id_membresia,
                        membresia => membresia.id_membresia,
                        (detalleMembresia, membresia) => new ClienteTipoCliente
                        {
                            id_cliente = detalleMembresia.cliente.id_cliente,
                            tipoCliente = detalleMembresia.tipoCLiente.descripcion,
                            cedula = detalleMembresia.cliente.cedula,
                            nombre = detalleMembresia.cliente.nombre,
                            apellido = detalleMembresia.cliente.apellido,
                            direccion = detalleMembresia.cliente.direccion,
                            telefono = detalleMembresia.cliente.telefono,
                            email = detalleMembresia.cliente.email,
                            fecha_nacimiento = (DateTime)detalleMembresia.cliente.fecha_nacimiento,
                            peso = (decimal)detalleMembresia.cliente.peso,
                            altura = (decimal)detalleMembresia.cliente.altura,
                            estado = detalleMembresia.cliente.estado,
                            membresia = membresia.descripcion,
                            foto = (byte[])detalleMembresia.cliente.foto

                        }).Where(ct => ct.membresia.Equals(membresias) && ct.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return clientesMembresia.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public void Guardarfoto(int idCliente, byte[] foto)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    var fotoCliente = context.Cliente.Find(idCliente);
                    if(fotoCliente != null)
                    {
                        fotoCliente.foto = foto;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<ClienteMembresiaCosto> ListarClientesActivosMiembros()
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesActivosMiembros = context.Cliente
                    .Join(context.Tipo_Cliente,
                        c => c.id_tipo_cliente,
                        t => t.id_tipo_cliente,
                       (cliente, tipoCLiente) => new { cliente, tipoCLiente })
                    .Join(context.Membresias,
                        detalleMembresia => detalleMembresia.cliente.id_membresia,
                        membresia => membresia.id_membresia,
                        (detalleMembresia, membresia) => new {detalleMembresia, membresia })
                    .Join(context.Costo_Membresia,
                        membresiasCosto => membresiasCosto.membresia.id_costo_membresia,
                        costoMembresia => costoMembresia.id_costo_membresia,
                        (membresiasCosto, costoMembresias) => new {membresiasCosto, costoMembresias})
                    .Join(context.Tipo_Membresia,
                        membresiaDatos => membresiaDatos.costoMembresias.id_tipo_membresia,
                        tipoMembresia => tipoMembresia.id_tipo_membresia,
                        (membresiaDatos, tipoMembresia) => new { membresiaDatos, tipoMembresia })
                    .Join(context.Registro_Asistencia,
                        clienteMembresiaDatos => clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.id_cliente,
                        registroAsistencia => registroAsistencia.id_cliente, 
                        (clienteMembresiaDatos, registroAsistencia) => new ClienteMembresiaCosto
                        {
                            id_cliente = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.id_cliente,
                            tipoCliente = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.tipoCLiente.descripcion,
                            cedula = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.cedula,
                            nombre = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.nombre,
                            membresia = clienteMembresiaDatos.membresiaDatos.membresiasCosto.membresia.descripcion,
                            fecha_inicio = (DateTime)clienteMembresiaDatos.membresiaDatos.membresiasCosto.membresia.fecha_inicio,
                            fecha_fin = (DateTime)clienteMembresiaDatos.membresiaDatos.membresiasCosto.membresia.fecha_fin,
                            tipoMembresia = clienteMembresiaDatos.tipoMembresia.descripcion,
                            costo = (decimal)clienteMembresiaDatos.membresiaDatos.costoMembresias.valor,
                            fecha_asistencia = (DateTime)registroAsistencia.fecha,
                            id_registro = (int)registroAsistencia.id_registro,
                            estado = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.estado
                        }).Where(c => c.tipoCliente.Equals("Miembro") && c.estado.Equals(true) && c.fecha_asistencia != null).ToList();
                    //3.- retorno resultado
                    return clientesActivosMiembros.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<ClienteMembresiaCosto> ClientesActivos()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesActivosMiembros = context.Cliente
                    .Join(context.Tipo_Cliente,
                        c => c.id_tipo_cliente,
                        t => t.id_tipo_cliente,
                       (cliente, tipoCLiente) => new { cliente, tipoCLiente })
                    .Join(context.Membresias,
                        detalleMembresia => detalleMembresia.cliente.id_membresia,
                        membresia => membresia.id_membresia,
                        (detalleMembresia, membresia) => new { detalleMembresia, membresia })
                    .Join(context.Costo_Membresia,
                        membresiasCosto => membresiasCosto.membresia.id_costo_membresia,
                        costoMembresia => costoMembresia.id_costo_membresia,
                        (membresiasCosto, costoMembresias) => new { membresiasCosto, costoMembresias })
                    .Join(context.Tipo_Membresia,
                        membresiaDatos => membresiaDatos.costoMembresias.id_tipo_membresia,
                        tipoMembresia => tipoMembresia.id_tipo_membresia,
                        (membresiaDatos, tipoMembresia) => new ClienteMembresiaCosto
                        {
                            id_cliente = membresiaDatos.membresiasCosto.detalleMembresia.cliente.id_cliente,
                            tipoCliente = membresiaDatos.membresiasCosto.detalleMembresia.tipoCLiente.descripcion,
                            cedula = membresiaDatos.membresiasCosto.detalleMembresia.cliente.cedula,
                            nombre = membresiaDatos.membresiasCosto.detalleMembresia.cliente.nombre,
                            telefono = membresiaDatos.membresiasCosto.detalleMembresia.cliente.telefono,
                            membresia = membresiaDatos.membresiasCosto.membresia.descripcion,
                            fecha_inicio = (DateTime)membresiaDatos.membresiasCosto.membresia.fecha_inicio,
                            fecha_fin = (DateTime)membresiaDatos.membresiasCosto.membresia.fecha_fin,
                            tipoMembresia = tipoMembresia.descripcion,
                            costo = (decimal)membresiaDatos.costoMembresias.valor,
                            estado = membresiaDatos.membresiasCosto.detalleMembresia.cliente.estado
                        }).Where(c => c.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return clientesActivosMiembros.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<ClienteMembresiaCosto> ListarClientesCedulaMiembros(string cedula)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesActivosMiembros = context.Cliente
                    .Join(context.Tipo_Cliente,
                        c => c.id_tipo_cliente,
                        t => t.id_tipo_cliente,
                       (cliente, tipoCLiente) => new { cliente, tipoCLiente })
                    .Join(context.Membresias,
                        detalleMembresia => detalleMembresia.cliente.id_membresia,
                        membresia => membresia.id_membresia,
                        (detalleMembresia, membresia) => new { detalleMembresia, membresia })
                    .Join(context.Costo_Membresia,
                        membresiasCosto => membresiasCosto.membresia.id_costo_membresia,
                        costoMembresia => costoMembresia.id_costo_membresia,
                        (membresiasCosto, costoMembresias) => new { membresiasCosto, costoMembresias })
                    .Join(context.Tipo_Membresia,
                        membresiaDatos => membresiaDatos.costoMembresias.id_tipo_membresia,
                        tipoMembresia => tipoMembresia.id_tipo_membresia,
                        (membresiaDatos, tipoMembresia) => new { membresiaDatos, tipoMembresia })
                    .Join(context.Registro_Asistencia,
                        clienteMembresiaDatos => clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.id_cliente,
                        registroAsistencia => registroAsistencia.id_cliente,
                        (clienteMembresiaDatos, registroAsistencia) => new ClienteMembresiaCosto
                        {
                            id_cliente = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.id_cliente,
                            tipoCliente = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.tipoCLiente.descripcion,
                            cedula = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.cedula,
                            nombre = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.nombre,
                            membresia = clienteMembresiaDatos.membresiaDatos.membresiasCosto.membresia.descripcion,
                            fecha_inicio = (DateTime)clienteMembresiaDatos.membresiaDatos.membresiasCosto.membresia.fecha_inicio,
                            fecha_fin = (DateTime)clienteMembresiaDatos.membresiaDatos.membresiasCosto.membresia.fecha_fin,
                            tipoMembresia = clienteMembresiaDatos.tipoMembresia.descripcion,
                            costo = (decimal)clienteMembresiaDatos.membresiaDatos.costoMembresias.valor,
                            fecha_asistencia = (DateTime)registroAsistencia.fecha,
                            id_registro = (int)registroAsistencia.id_registro,
                            estado = clienteMembresiaDatos.membresiaDatos.membresiasCosto.detalleMembresia.cliente.estado
                        }).Where(c => c.tipoCliente.Equals("Miembro") && c.estado.Equals(true) && c.fecha_asistencia != null && c.cedula.Equals(cedula)).ToList();
                    //3.- retorno resultado
                    return clientesActivosMiembros.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
