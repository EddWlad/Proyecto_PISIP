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
    public class MembresiasControlador
    {
        private MembresiasServicio servicio;
        public MembresiasControlador()
        {
            servicio = new MembresiasServicio();
        }
        public bool InsertarMembresia(MembresiasVistaModelo membresiaVistaModelo)
        {
           Membresias membresiaDB = new Membresias();
           try
            {
                membresiaDB.fecha_registro= membresiaVistaModelo.Fecha_Registro;
                membresiaDB.descripcion = membresiaVistaModelo.Descripcion;
                membresiaDB.fecha_inicio = membresiaVistaModelo.Fecha_Inicio;
                membresiaDB.fecha_fin = membresiaVistaModelo.Fecha_Fin;
                membresiaDB.estado = membresiaVistaModelo.Estado;
                membresiaDB.id_tipo_membresia = membresiaVistaModelo.Id_Tipo_Membresia;
                membresiaDB.id_costo_membresia = membresiaVistaModelo.Id_Costo_Membresia;
                membresiaDB.id_promocion = membresiaVistaModelo.Id_Promocion;
                servicio.InsertarMembresias(membresiaDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ModificarMembresia(MembresiasVistaModelo membresiaVistaModelo)
        {
            Membresias membresiaDB = new Membresias();
            try
            {
                membresiaDB.id_membresia = membresiaVistaModelo.Id_Membresia;
                membresiaDB.fecha_registro = membresiaVistaModelo.Fecha_Registro;
                membresiaDB.descripcion = membresiaVistaModelo.Descripcion;
                membresiaDB.fecha_inicio = membresiaVistaModelo.Fecha_Inicio;
                membresiaDB.fecha_fin = membresiaVistaModelo.Fecha_Fin;
                membresiaDB.estado = membresiaVistaModelo.Estado;
                membresiaDB.id_tipo_membresia = membresiaVistaModelo.Id_Tipo_Membresia;
                membresiaDB.id_costo_membresia = membresiaVistaModelo.Id_Costo_Membresia;
                membresiaDB.id_promocion = membresiaVistaModelo.Id_Promocion;
                servicio.ModificarMembresia(membresiaDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public IEnumerable<Membresias> ListarMembresiasTipo(string tipo)
        //{
        //return servicio.ListarMembresiasTipo(tipo);
        //}

        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasActivas()
        {
            return servicio.ListarMembresiasActivas();
        }

        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasPromocion(string promocion)
        {
            return servicio.ListarMembresiasPromocion(promocion);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasTipo(string tipo)
        {
            return servicio.ListarMembresiasTipo(tipo);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasFechaRegistro(DateTime fehca_registro)
        {
            return servicio.ListarMembresiasFechaRegistro(fehca_registro);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasFechafin(DateTime fehca_fin)
        {
            return servicio.ListarMembresiasFechaFin(fehca_fin);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasFechaInicio(DateTime fecha_inicio)
        {
            return servicio.ListarMembresiasFechaInicio(fecha_inicio);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasCosto(decimal costo)
        {
            return servicio.ListarMembresiasCosto(costo);
        }
        public bool EliminarMembresia(int id)
        {
            return servicio.EliminarMembresia(id);

        }

    }
}
