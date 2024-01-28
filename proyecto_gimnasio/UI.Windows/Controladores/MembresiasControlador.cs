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

        //public IEnumerable<Membresias> ListarMembresiasTipo(string tipo)
        //{
            //return servicio.ListarMembresiasTipo(tipo);
        //}

        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasActivas()
        {
            return servicio.ListarMembresiasActivas();
        }
        public IEnumerable<Membresias> ListarMembresiasEstado(bool estado)
        {
            return servicio.ListarMembresiasEstado(estado);
        }
    }
}
