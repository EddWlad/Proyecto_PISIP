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
                promocionDB.fecha_registro = promocionVistaModelo.Fecha_registro;
                promocionDB.descripcion = promocionVistaModelo.Descripcion;
                promocionDB.fecha_inicio = promocionVistaModelo.Fecha_inicio;
                promocionDB.fecha_fin = promocionVistaModelo.Fecha_fin;
                promocionDB.estado = promocionVistaModelo.Estado;
                servicio.InsertarPromociones(promocionDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarPromocion(PromocionesVistaModelo promocionVistaModelo)
        {
            Promociones promocionDB = new Promociones();
            try
            {
                promocionDB.id_promocion = promocionVistaModelo.Id_promocion;
                promocionDB.fecha_registro = promocionVistaModelo.Fecha_registro;
                promocionDB.descripcion = promocionVistaModelo.Descripcion;
                promocionDB.fecha_inicio = promocionVistaModelo.Fecha_inicio;
                promocionDB.fecha_fin = promocionVistaModelo.Fecha_fin;
                promocionDB.estado = promocionVistaModelo.Estado;
                servicio.ModificarPromociones(promocionDB);
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
        public bool EliminarPromocion(int id)
        {
            return servicio.EliminarPromocion(id);

        }
    }
}
