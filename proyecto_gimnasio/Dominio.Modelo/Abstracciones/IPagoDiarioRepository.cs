using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface IPagoDiarioRepository : IBaseRepository<Pago_diario>
    {
        IEnumerable<Pago_diario> ListarPagosFecha(DateTime fecha);
        IEnumerable<PagoDiarioRegistro> ListarPagosActivos();
    }
}
