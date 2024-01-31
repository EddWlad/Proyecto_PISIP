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
    public class TipoClienteControlador
    {
        private TipoClienteServicio servicio;
        public TipoClienteControlador()
        {
            servicio = new TipoClienteServicio();
        }
        public bool InsertarTipoCliente(TipoClienteVistaModelo tipoClienteVistaModelo)
        {
            Tipo_Cliente tipoclienteDB = new Tipo_Cliente();
            try
            {
                tipoclienteDB.descripcion = tipoClienteVistaModelo.Descripcion;
                tipoclienteDB.estado = tipoClienteVistaModelo.Estado;
                servicio.InsertarTipoCliente(tipoclienteDB);
                return true;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ModificarTipoCliente(TipoClienteVistaModelo tipoClienteVistaModelo)
        {
            Tipo_Cliente tipoclienteDB = new Tipo_Cliente();
            try
            {
                tipoclienteDB.id_tipo_cliente = tipoClienteVistaModelo.Id_tipo_cliente;
                tipoclienteDB.descripcion = tipoClienteVistaModelo.Descripcion;
                tipoclienteDB.estado = tipoClienteVistaModelo.Estado;
                servicio.ModificarTipoCliente(tipoclienteDB);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Tipo_Cliente> ListarTipoClienteDescripcion(string descripcion)
        {
            return servicio.ListarTipoClientesDescripcion(descripcion);
        }
        public IEnumerable<Tipo_Cliente> ListarTipoClientesActivos()
        {
            return servicio.ListarTiposActivos();
        }
        public bool EliminarTipoCleinte(int id)
        {
            return servicio.EliminarTipoCliente(id);

        }
    }
}
