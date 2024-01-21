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
    public class PagoDiarioControlador
    {
        private PagoDiarioServicio servicio;
        
        public PagoDiarioControlador()
        {
            servicio = new PagoDiarioServicio();
        }
        public bool InsertarPagoDiario(PagoDiarioVistaModelo pagosDiariosVistaModelo)
        {
            DateTime fechaActual = DateTime.Now;
            Pago_diario pagodiarioDB = new Pago_diario();
            try
            {
                pagodiarioDB.fecha = fechaActual;
                pagodiarioDB.monto = pagosDiariosVistaModelo.Monto;
                pagodiarioDB.estado = pagosDiariosVistaModelo.Estado;
                
                servicio.InsertarPagos(pagodiarioDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Pago_diario> ListarPagoDiarioFecha(DateTime fecha)
        {
            return servicio.ListarPagoDiarioFecha(fecha);
        }

        public IEnumerable<Pago_diario> ListarPagoDiarioActivos()
        {
            return servicio.ListarPagosDiariosActivos();
        }
    }
}
