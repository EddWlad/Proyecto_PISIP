using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface ITipoMembresiaRepository : IBaseRepository<Tipo_Membresia>
    {
        IEnumerable<Tipo_Membresia> ListarTipoMembresias(String descripcion);
        IEnumerable<Tipo_Membresia> ListarTipoMembresiasActivas();
    }
}
