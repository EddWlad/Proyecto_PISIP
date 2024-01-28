using Aplicacion.Servicio;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Windows.VistaModelos;

namespace UI.Windows.Controladores
{
    public class TipoMembresiaControlador
    {
        private TipoMembresiaServicio servicio;
        public TipoMembresiaControlador()
        {
            servicio = new TipoMembresiaServicio();
        }
        public bool InsertarTipoMembresia(TipoMembresiaVistaModelo tipoMembresiaVistaModelo)
        {
            Tipo_Membresia tipoMembresiaDB = new Tipo_Membresia();
            try
            {
                tipoMembresiaDB.descripcion = tipoMembresiaVistaModelo.Descripcion;
                tipoMembresiaDB.estado = tipoMembresiaVistaModelo.Estado;
                servicio.InsertarTipoMembresia(tipoMembresiaDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<Tipo_Membresia> ListarTipoMembresiaDescripcion(string descripcion)
        {
            return servicio.ListarTipoMembresiaDescripcion(descripcion);
        }
        public IEnumerable<Tipo_Membresia> ListarTipoMembresiasActivas()
        {
            return servicio.ListarTiposMembresiasActivos();
        }
    }
}
