using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Entidades
{
    public class ClienteMembresiaCosto
    {
        public int id_cliente { get; set; }
        public string tipoCliente { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string membresia { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string tipoMembresia { get; set; }
        public decimal costo { get; set; }
        public DateTime fecha_asistencia { get; set; }
        public int id_registro { get; set; }
        public bool estado { get; set; }
        
    }
}
