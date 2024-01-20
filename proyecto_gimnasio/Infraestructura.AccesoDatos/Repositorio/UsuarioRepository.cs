using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public IEnumerable<Usuario> ListarUsuariosActivos()
        {
                //1.- conectar a la base
                try
                {
                    using (var context = new gestion_membresiasEntities())
                    {
                        //2.- escribil la consulta
                        var usuariosListar = from e in context.Usuario
                                             where e.estado == true
                                             select e;
                        //3.- retorno resultado
                        return usuariosListar.ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudieron recuperar los registro.", ex);
                } 
        }
    }
}
