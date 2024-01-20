using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
    public class UsuarioServicio
    {
        readonly IUsuarioRepository usuarioRepository;
        public UsuarioServicio()
        {
            usuarioRepository = new UsuarioRepository();
        }
        public IEnumerable<Usuario> ListarUsuarios() // tiene una clase generica, los metodos deben tener el mismo nombre de la arqutectura
        {
            return this.usuarioRepository.GetAll();
        }

        public IEnumerable<Usuario> ListarEmpleadosActivos()
        {
            return this.usuarioRepository.ListarUsuariosActivos();
        }
    }
}
