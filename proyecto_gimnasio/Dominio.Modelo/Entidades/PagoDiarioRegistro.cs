using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Entidades
{
    public class PagoDiarioRegistro
    {
        public int id_pago_diario { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public decimal costo { get; set; }
        public bool estado { get; set; }
    }
}
