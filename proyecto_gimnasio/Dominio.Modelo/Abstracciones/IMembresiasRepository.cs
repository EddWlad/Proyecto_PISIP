using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface IMembresiasRepository : IBaseRepository<Membresias>
    {
        IEnumerable<MembresiaTipoCostoPromocion> MembresiaFechaRegistro(DateTime fecha_registro);
        IEnumerable<MembresiaTipoCostoPromocion> MembresiaFechaInicio(DateTime fecha_inicio);
        IEnumerable<MembresiaTipoCostoPromocion> MembresiaFechaFin(DateTime fecha_fin);
        IEnumerable<MembresiaTipoCostoPromocion> MembresiaTipos(String tipo);
        IEnumerable<MembresiaTipoCostoPromocion> MembresiaCosto(decimal costo);
        IEnumerable<MembresiaTipoCostoPromocion> MembresiaPromocion(String promocion);
        IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasActivas();
        bool ElminarMmebresia(int id);

    }
}
