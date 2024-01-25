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
        public IEnumerable<Cliente> ListarClienteNombre(string nombre)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesNombre = from e in context.Cliente
                                         where e.nombre == nombre
                                         select e;
                    //3.- retorno resultado
                    return clientesNombre.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Cliente> ListarClientesActivos()
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesActivos = from e in context.Cliente
                                         where e.estado == true
                                         select e;
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

        //public IEnumerable<Cliente> ListarClientesMembresia(string membresia)
        //{

        //}
    }
}
