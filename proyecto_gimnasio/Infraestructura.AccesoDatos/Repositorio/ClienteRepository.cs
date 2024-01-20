using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Cliente> ListarClientesEstados(bool estado)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var clientesEstados = from e in context.Cliente
                                          where e.estado == estado
                                          select e;
                    //3.- retorno resultado
                    return clientesEstados.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Cliente> ListarClientesMembresia(string membresia)
        {
           
        }
    }
}
