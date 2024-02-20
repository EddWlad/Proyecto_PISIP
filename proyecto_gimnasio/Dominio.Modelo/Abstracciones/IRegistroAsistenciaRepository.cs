using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface IRegistroAsistenciaRepository: IBaseRepository<Registro_Asistencia>
    {
        bool EliminarRegistro(int id);
        IEnumerable<Registro_Asistencia> ListarAsistenciaFecha(string fecha);
        IEnumerable<AsistenciaCliente> ListarAsistencias();
        IEnumerable<AsistenciaCliente> ListarAsistenciasFrecuentes();
        IEnumerable<AsistenciaCliente> ListarAsistenciasMiembros();
        IEnumerable<AsistenciaCliente> ListarAsistenciaCedula(string cedula);
    }
}
