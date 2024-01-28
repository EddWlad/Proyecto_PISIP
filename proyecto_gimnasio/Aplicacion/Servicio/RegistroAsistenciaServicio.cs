using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
    public class RegistroAsistenciaServicio
    {
        readonly IRegistroAsistenciaRepository registroAsistenciaRepository;
        public RegistroAsistenciaServicio()
        {
            registroAsistenciaRepository = new RegistroAsistenciaRepository();
        }
        public IEnumerable<Registro_Asistencia> ListarAsistencia()
        {
            return this.registroAsistenciaRepository.GetAll();
        }
        public void InsertarAsistencia(Registro_Asistencia nuevaAsistencia)
        {
            this.registroAsistenciaRepository.Add(nuevaAsistencia);
        }
        public void ModificarAsistencia(Registro_Asistencia modificadoAsistencia)
        {
            this.registroAsistenciaRepository.Modify(modificadoAsistencia);
        }
        public IEnumerable<Registro_Asistencia> ListarAsistenciaFechas(DateTime fecha)
        {
            return this.registroAsistenciaRepository.ListarAsistenciaFecha(fecha);
        }
        public IEnumerable<AsistenciaCliente> ListarAsistenciaClientes()
        {
            return this.registroAsistenciaRepository.ListarAsistencias();
        }
    }
}
