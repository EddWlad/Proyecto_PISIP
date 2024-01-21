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
        IEnumerable<Membresias> ListarMembresiasTipo(String tipo);
        IEnumerable<Membresias> ListarMembresiasActivas();
        IEnumerable<Membresias> ListarMembresiasEstados(Boolean estado);
    }
}
