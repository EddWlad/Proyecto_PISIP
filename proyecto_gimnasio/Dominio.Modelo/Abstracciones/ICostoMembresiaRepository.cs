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
        IEnumerable<Costo_Membresia> ListarCostoMembresia(String descripcion);
        IEnumerable<Costo_Membresia> ListarCostosMembresiasActivas();
    }
}
