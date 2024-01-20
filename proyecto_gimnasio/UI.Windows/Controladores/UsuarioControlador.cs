using Aplicacion.Servicio;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.Controladores
{
    public class UsuarioControlador
    {
        private UsuarioServicio servicio;
        public UsuarioControlador()
        {
            servicio = new UsuarioServicio();
        }
        public IEnumerable<Usuario> ListarUsuariosActivos()
        {
            return servicio.ListarEmpleadosActivos();
        }
    }
}
