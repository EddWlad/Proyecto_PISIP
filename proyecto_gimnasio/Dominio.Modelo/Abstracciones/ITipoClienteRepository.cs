using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface ITipoClienteRepository : IBaseRepository<Tipo_Cliente>
    {
        IEnumerable<Tipo_Cliente> ListarTipoClientes(String descripcion);
        IEnumerable<Tipo_Cliente> ListarTiposActivos();

    }
}
