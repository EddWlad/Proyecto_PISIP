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
                pagodiarioDB.id_registro = pagosDiariosVistaModelo.Id_Registro;
                servicio.InsertarPagos(pagodiarioDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<PagoDiarioRegistro> ListarPagoDiarioFecha(DateTime fecha)
        {
            return servicio.ListarPagoDiarioFecha(fecha);
        }

        public IEnumerable<PagoDiarioRegistro> ListarPagoDiarioActivos()
        {
            return servicio.ListarPagosDiariosActivos();
        }
        public bool EliminarCliente(int id)
        {
            return servicio.EliminarPago(id);

        }
        public IEnumerable<PagoDiarioRegistro> ListarPagosTipo(string tipo)
        {
            return servicio.ListarPagosTipo(tipo);
        }
        public IEnumerable<PagoDiarioRegistro> ListarPagosCedula(string cedula)
        {
            return servicio.ListarPagosCedula(cedula);
        }
    }
}
