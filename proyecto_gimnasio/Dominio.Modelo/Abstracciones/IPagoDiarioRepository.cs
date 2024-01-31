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
        IEnumerable<PagoDiarioRegistro> ListarPagosFecha(DateTime fecha);
        IEnumerable<PagoDiarioRegistro> ListarPagosActivos();

        IEnumerable<PagoDiarioRegistro> ListarPagosCedula(String cedula);
        IEnumerable<PagoDiarioRegistro> ListarPagosTipoCliente(String tipo);



        bool ElminarPago(int id);
    }
}
