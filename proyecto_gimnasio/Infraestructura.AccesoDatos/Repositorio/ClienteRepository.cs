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
                            peso = (decimal)detalleMembresia.cliente.peso,
                            altura = (decimal)detalleMembresia.cliente.altura,
                            estado = detalleMembresia.cliente.estado,
                            membresia = membresia.descripcion,

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
                           peso = (decimal)detalleMembresia.cliente.peso,
                           altura = (decimal)detalleMembresia.cliente.altura,
                           estado = detalleMembresia.cliente.estado,
                           membresia = membresia.descripcion,

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
                            peso = (decimal)detalleMembresia.cliente.peso,
                            altura = (decimal)detalleMembresia.cliente.altura,
                            estado = detalleMembresia.cliente.estado,
                            membresia = membresia.descripcion,

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
                            peso = (decimal)detalleMembresia.cliente.peso,
                            altura = (decimal)detalleMembresia.cliente.altura,
                            estado = detalleMembresia.cliente.estado,
                            membresia = membresia.descripcion,

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
                            peso = (decimal)detalleMembresia.cliente.peso,
                            altura = (decimal)detalleMembresia.cliente.altura,
                            estado = detalleMembresia.cliente.estado,
                            membresia = membresia.descripcion,

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
    }
}
