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
        IEnumerable<Registro_Asistencia> ListarAsistenciaFecha(DateTime fecha);
        IEnumerable<AsistenciaCliente> ListarAsistencias();
    }
}
