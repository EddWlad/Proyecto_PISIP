using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface IPromocionesRepository : IBaseRepository<Promociones>
    {
        IEnumerable<Promociones> ListarPromocionesTipo(String tipo);
        IEnumerable<Promociones> ListarPromocionesActivas();
        IEnumerable<Promociones> ListarPromocionesVigentes(DateTime fechaActual);
        bool ElminarPromocion(int id);

    }
}
