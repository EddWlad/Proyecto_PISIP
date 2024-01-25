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
        //public bool InsertarMembresia(MembresiasVistaModelo membresiaVistaModelo)
        //{
           //Membresias membresiaDB = new Membresias();
           // try
            //{
                //membresiaDB.tipo= membresiaVistaModelo.Tipo;
                //membresiaDB.costo = membresiaVistaModelo.Costo;
                //membresiaDB.descripcion = membresiaVistaModelo.Descripcion;
                //membresiaDB.estado = membresiaVistaModelo.Estado;
                //servicio.InsertarMembresias(membresiaDB);
                //return true;
            //}
            //catch (Exception ex)
            //{
                //return false;
            //}
        //}

        //public IEnumerable<Membresias> ListarMembresiasTipo(string tipo)
        //{
            //return servicio.ListarMembresiasTipo(tipo);
        //}

        public IEnumerable<Membresias> ListarMembresiasActivas()
        {
            return servicio.ListarMembresiasActivas();
        }
        public IEnumerable<Membresias> ListarMembresiasEstado(bool estado)
        {
            return servicio.ListarMembresiasEstado(estado);
        }
    }
}
