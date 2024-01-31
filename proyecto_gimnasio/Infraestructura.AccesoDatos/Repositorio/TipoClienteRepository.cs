using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class TipoClienteRepository : BaseRepository<Tipo_Cliente>, ITipoClienteRepository
    {
        public IEnumerable<Tipo_Cliente> ListarTipoClientes(string descripcion)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var tiposClientes = from e in context.Tipo_Cliente
                                         where e.descripcion == descripcion && e.estado == true
                                         select e;
                    //3.- retorno resultado
                    return tiposClientes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Tipo_Cliente> ListarTiposActivos()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var tiposActivos = from e in context.Tipo_Cliente
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
        public void ModificarClientes(Tipo_Cliente tipoClienteActualizado)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var tipoCliente = context.Tipo_Cliente.FirstOrDefault(c => c.id_tipo_cliente == tipoClienteActualizado.id_tipo_cliente);
                    if (tipoCliente != null)
                    {
                        // 2.- Actualizar los campos necesarios
                        tipoCliente.descripcion = tipoClienteActualizado.descripcion;
                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();

                    }
                    else
                    {
                        throw new Exception("El valor de tipo es nulo");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el registro del tipo.", ex);
            }
        }
        public bool ElminarTipoCliente(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var tipoCliente = context.Tipo_Cliente.FirstOrDefault(c => c.id_tipo_cliente == id);
                    if (tipoCliente != null)
                    {
                        // 2.- Actualizar los campos necesarios

                        tipoCliente.estado = false;


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
    }
}
