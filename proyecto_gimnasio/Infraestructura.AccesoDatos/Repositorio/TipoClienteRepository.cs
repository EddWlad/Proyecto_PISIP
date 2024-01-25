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
                                         where e.descripcion == descripcion
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
    }
}
