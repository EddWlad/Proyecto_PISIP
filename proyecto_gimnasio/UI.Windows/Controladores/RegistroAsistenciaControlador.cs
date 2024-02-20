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
    public class RegistroAsistenciaControlador
    {
        private RegistroAsistenciaServicio servicio;
        public RegistroAsistenciaControlador()
        {
            servicio = new RegistroAsistenciaServicio();
        }
        public bool InsertarAsistencia(RegistroAsistenciaVistaModelo registroAsistenciaVistaModelo)
        {
            Registro_Asistencia asistenciaDB = new Registro_Asistencia();
            try
            {
                asistenciaDB.fecha = registroAsistenciaVistaModelo.Fecha;
                asistenciaDB.estado = registroAsistenciaVistaModelo.Estado;
                asistenciaDB.id_cliente = (int)registroAsistenciaVistaModelo.Id_Cliente;
                servicio.InsertarAsistencia(asistenciaDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EliminarRegistro(int id)
        {
            return servicio.EliminarRegistro(id);

        }
        public IEnumerable<Registro_Asistencia> ListarAsistenciaFechas(string fecha)
        {
            return servicio.ListarAsistenciaFechas(fecha);
        }
        public IEnumerable<AsistenciaCliente> ListarAsistenciasClientes()
        {
            return servicio.ListarAsistenciaClientes();
        }
        public IEnumerable<AsistenciaCliente> ListarAsistenciasCedula(string cedula)
        {
            return servicio.ListarAsistenciasCedula(cedula);
        }
        public IEnumerable<AsistenciaCliente> ListarAsistenciasClientesFrecuentes()
        {
            return servicio.ListarAsistenciaClientesFrecuentes();
        }
        public IEnumerable<AsistenciaCliente> ListarAsistenciasClientesMiembros()
        {
            return servicio.ListarAsistenciaClientesMiembros();
        }
    }
}
