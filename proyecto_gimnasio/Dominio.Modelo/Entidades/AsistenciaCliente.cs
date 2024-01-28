using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Entidades
{
    public class AsistenciaCliente
    {
        public int id_registro { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; }
    }
}
