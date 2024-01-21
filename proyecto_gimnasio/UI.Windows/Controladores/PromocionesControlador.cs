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
    public class PromocionesControlador
    {
        private PromocionesServicio servicio;
        public PromocionesControlador()
        {
            servicio = new PromocionesServicio();
        }
        public bool InsertarPromocion(PromocionesVistaModelo promocionVistaModelo)
        {
            Promociones promocionDB = new Promociones();
            try
            {
                promocionDB.tipo = promocionVistaModelo.Tipo;
                promocionDB.descripcion = promocionVistaModelo.Descripcion;
                promocionDB.costo = promocionVistaModelo.Costo;
                promocionDB.estado = promocionVistaModelo.Estado;
                servicio.InsertarPromociones(promocionDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Promociones> ListarPromocionesTipo(string tipo)
        {
            return servicio.ListarPromocionesTipo(tipo);
        }

        public IEnumerable<Promociones> ListarPromocionesActivas()
        {
            return servicio.ListarPromocionesActivas();
        }
        public IEnumerable<Promociones> ListarPromocionesEstado(bool estado)
        {
            return servicio.ListarPromocionesEstado(estado);
        }
    }
}
