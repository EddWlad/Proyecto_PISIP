using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface ICostoMembresiaRepository : IBaseRepository<Costo_Membresia>
    {
        IEnumerable<MembresiaTipoCosto> ListarCostoMembresia(String descripcion);
        IEnumerable<MembresiaTipoCosto> ListarCosto(Decimal costo);
        IEnumerable<Costo_Membresia> ListarCostosMembresiasActivas();
        IEnumerable<MembresiaTipoCosto> ListarMembresiasCostoTipo();
        bool EliminarCostoMembresia(int id);
    }
}
