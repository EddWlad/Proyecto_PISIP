using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        IEnumerable<Cliente> ListarClienteNombre(String nombre);
        IEnumerable<Cliente> ListarClientesActivos();
        
    }
}

