using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Entidades
{
    public class MembresiaTipoCostoPromocion
    {
        public int id_membresia { get; set; }
        public DateTime fecha_registro { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string tipoMembresia { get; set; }
        public decimal costo { get; set; }
        public string promocion { get; set; }
        public bool estado { get; set; }
    }
}
